// HW3 - Bill Calculation with Discount and BillLine extension
// .NET 6+ Console App (C# 10)

using System;
using System.Collections.Generic;
using System.Globalization;

namespace HW3
{
    // ==========================
    // Basic domain classes
    // ==========================
    public class Employee
    {
        public string Name { get; }
        public Employee(string name) => Name = name;
        public override string ToString() => Name;
    }

    public class Item
    {
        public string Name { get; }
        public double Price { get; }        // full price
        public double Discount { get; }     // absolute discount amount (e.g., 0.25)

        public Item(string name, double price, double discount = 0.0)
        {
            if (price < 0) throw new ArgumentOutOfRangeException(nameof(price));
            if (discount < 0) throw new ArgumentOutOfRangeException(nameof(discount));
            if (discount > price) throw new ArgumentException("Discount cannot exceed price.");

            Name = name;
            Price = price;
            Discount = discount;
        }

        // Methods following the spec’s naming
        public double getPrice() => Price;
        public double getDiscount() => Discount;

        public override string ToString()
            => $"{Name}  price={Price.ToString("F2", CultureInfo.InvariantCulture)}  discount={Discount.ToString("F2", CultureInfo.InvariantCulture)}";
    }

    // ==========================
    // Part 1: GroceryBill (no discount logic inside)
    // ==========================
    public class GroceryBill
    {
        protected readonly Employee Clerk;
        protected readonly List<Item> Items = new();

        public GroceryBill(Employee clerk) => Clerk = clerk;

        // spec: public void add(Item i)
        public virtual void add(Item i)
        {
            if (i == null) throw new ArgumentNullException(nameof(i));
            Items.Add(i);
        }

        // spec: public double getTotal() -> sum of full prices
        public virtual double getTotal()
        {
            double sum = 0.0;
            foreach (var it in Items) sum += it.getPrice();
            return sum;
        }

        // spec: public void printReceipt()
        public virtual void printReceipt()
        {
            Console.WriteLine("==== Receipt ====");
            Console.WriteLine($"Clerk: {Clerk}");
            foreach (var it in Items)
            {
                Console.WriteLine($"- {it.Name,-20} Price: {it.getPrice():F2}");
            }
            Console.WriteLine($"TOTAL (no discount): {getTotal():F2}");
            Console.WriteLine("=================\n");
        }
    }

    // ==========================
    // Part 2: DiscountBill extends GroceryBill
    // ==========================
    public class DiscountBill : GroceryBill
    {
        private readonly bool preferred;
        private int discountCount = 0;
        private double discountAmount = 0.0;   // total absolute discount across all items

        // spec: public DiscountBill(Employee clerk, boolean preferred)
        public DiscountBill(Employee clerk, bool preferred) : base(clerk)
        {
            this.preferred = preferred;
        }

        // track discount stats when adding item
        public override void add(Item i)
        {
            base.add(i);
            if (preferred && i.getDiscount() > 0.0)
            {
                discountCount++;
                discountAmount += i.getDiscount();
            }
        }

        // spec: Adjust total for preferred customers
        public override double getTotal()
        {
            double baseTotal = base.getTotal();
            if (!preferred) return baseTotal;
            double net = baseTotal - discountAmount;
            return net < 0 ? 0 : net;
        }

        // spec: getters for discount info
        public int getDiscountCount() => preferred ? discountCount : 0;
        public double getDiscountAmount() => preferred ? discountAmount : 0.0;

        public double getDiscountPercent()
        {
            double baseTotal = base.getTotal();
            if (!preferred || baseTotal <= 1e-9) return 0.0;
            return (getDiscountAmount() / baseTotal) * 100.0;
        }

        public override void printReceipt()
        {
            Console.WriteLine("==== Discount Receipt ====");
            Console.WriteLine($"Clerk: {Clerk} | Preferred: {preferred}");
            foreach (var it in Items)
            {
                double eff = preferred ? (it.getPrice() - it.getDiscount()) : it.getPrice();
                Console.WriteLine($"- {it.Name,-20} Base: {it.getPrice():F2}  Disc: { (preferred ? it.getDiscount() : 0.0):F2}  => Pay: {eff:F2}");
            }
            double baseTotal = 0;
            foreach (var it in Items) baseTotal += it.getPrice();

            Console.WriteLine($"Subtotal (before discount): {baseTotal:F2}");
            Console.WriteLine($"Discount count: {getDiscountCount()} item(s)");
            Console.WriteLine($"Discount amount: {getDiscountAmount():F2}");
            Console.WriteLine($"Discount percent: {getDiscountPercent():F2}%");
            Console.WriteLine($"TOTAL TO PAY: {getTotal():F2}");
            Console.WriteLine("==========================\n");
        }
    }

    // ==========================
    // Extention: BillLine (Item + quantity)
    // ==========================
    public class BillLine
    {
        private int quantity = 1;
        private Item item;

        // spec: setters/getters (spelling kept close to PDF text)
        public void setQuantity(int q)
        {
            if (q <= 0) throw new ArgumentOutOfRangeException(nameof(q), "Quantity must be positive.");
            quantity = q;
        }

        public int getQuantity() => quantity;

        public Item setItem(Item i)
        {
            item = i ?? throw new ArgumentNullException(nameof(i));
            return item;
        }

        public Item getItem() => item ?? throw new InvalidOperationException("Item not set.");

        public double LineBaseTotal() => getItem().getPrice() * getQuantity();
        public double LineDiscountTotal(bool preferred) => preferred ? getItem().getDiscount() * getQuantity() : 0.0;

        public override string ToString()
        {
            var it = getItem();
            return $"{it.Name} x{quantity}  price={it.getPrice():F2}  discPerItem={it.getDiscount():F2}";
        }
    }

    // GroceryBill using BillLine
    public class GroceryBillWithLines
    {
        protected readonly Employee Clerk;
        protected readonly List<BillLine> Lines = new();

        public GroceryBillWithLines(Employee clerk) => Clerk = clerk;

        public virtual void add(BillLine line)
        {
            if (line == null) throw new ArgumentNullException(nameof(line));
            // ensure has item and quantity set
            _ = line.getItem();
            if (line.getQuantity() <= 0) throw new ArgumentException("Quantity must be positive.");
            Lines.Add(line);
        }

        public virtual double getTotal()
        {
            double total = 0.0;
            foreach (var ln in Lines)
                total += ln.LineBaseTotal();
            return total;
        }

        public virtual void printReceipt()
        {
            Console.WriteLine("==== Receipt (BillLine) ====");
            Console.WriteLine($"Clerk: {Clerk}");
            foreach (var ln in Lines)
            {
                Console.WriteLine($"- {ln}");
            }
            Console.WriteLine($"TOTAL (no discount): {getTotal():F2}");
            Console.WriteLine("===========================\n");
        }
    }

    // Discount version with BillLine
    public class DiscountBillWithLines : GroceryBillWithLines
    {
        private readonly bool preferred;
        private int discountCount = 0;     // number of distinct lines with non-zero discount
        private double discountAmount = 0; // total absolute discount across all quantities

        public DiscountBillWithLines(Employee clerk, bool preferred) : base(clerk)
        {
            this.preferred = preferred;
        }

        public override void add(BillLine line)
        {
            base.add(line);
            if (preferred && line.getItem().getDiscount() > 0.0)
            {
                discountCount += 1; // count lines; if you need per-item count, multiply by quantity instead
                discountAmount += line.LineDiscountTotal(preferred: true);
            }
        }

        public int getDiscountCount() => preferred ? discountCount : 0;
        public double getDiscountAmount() => preferred ? discountAmount : 0.0;

        public double getDiscountPercent()
        {
            double baseTotal = base.getTotal();
            if (!preferred || baseTotal <= 1e-9) return 0.0;
            return (getDiscountAmount() / baseTotal) * 100.0;
        }

        public override double getTotal()
        {
            double baseTotal = base.getTotal();
            if (!preferred) return baseTotal;
            double net = baseTotal - discountAmount;
            return net < 0 ? 0 : net;
        }

        public override void printReceipt()
        {
            Console.WriteLine("==== Discount Receipt (BillLine) ====");
            Console.WriteLine($"Clerk: {Clerk} | Preferred: {preferred}");

            foreach (var ln in Lines)
            {
                var it = ln.getItem();
                var qty = ln.getQuantity();
                var baseLine = ln.LineBaseTotal();
                var discLine = ln.LineDiscountTotal(preferred);
                var payLine = baseLine - discLine;

                Console.WriteLine($"- {it.Name,-18} x{qty,2}  Base: {baseLine:F2}  Disc: {(preferred ? discLine : 0.0):F2}  => Pay: {payLine:F2}");
            }

            double baseTotal = base.getTotal();
            Console.WriteLine($"Subtotal (before discount): {baseTotal:F2}");
            Console.WriteLine($"Discount count (lines): {getDiscountCount()}");
            Console.WriteLine($"Discount amount: {getDiscountAmount():F2}");
            Console.WriteLine($"Discount percent: {getDiscountPercent():F2}%");
            Console.WriteLine($"TOTAL TO PAY: {getTotal():F2}");
            Console.WriteLine("=====================================\n");
        }
    }

    // ==========================
    // Demo
    // ==========================
    public class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Sample data
            var clerk = new Employee("Alice");
            var i1 = new Item("Milk", 2.50, 0.10);
            var i2 = new Item("Bread", 1.80, 0.00);
            var i3 = new Item("Candy bar", 1.35, 0.25); // example in spec
            var i4 = new Item("Eggs", 3.20, 0.20);

            // --- Part 1: Original GroceryBill (no discount effect) ---
            var bill = new GroceryBill(clerk);
            bill.add(i1);
            bill.add(i2);
            bill.add(i3);
            bill.add(i4);
            bill.printReceipt();

            // --- Part 2: DiscountBill (preferred = true) ---
            var dBillPreferred = new DiscountBill(clerk, preferred: true);
            dBillPreferred.add(i1);
            dBillPreferred.add(i2);
            dBillPreferred.add(i3);
            dBillPreferred.add(i4);
            dBillPreferred.printReceipt();

            // --- Part 2: DiscountBill (preferred = false) ---
            var dBillNormal = new DiscountBill(clerk, preferred: false);
            dBillNormal.add(i1);
            dBillNormal.add(i2);
            dBillNormal.add(i3);
            dBillNormal.add(i4);
            dBillNormal.printReceipt();

            // --- Extention: BillLine version ---
            var clerk2 = new Employee("Bob");

            var line1 = new BillLine(); line1.setItem(i1); line1.setQuantity(2); // 2 Milk
            var line2 = new BillLine(); line2.setItem(i3); line2.setQuantity(3); // 3 Candy bars
            var line3 = new BillLine(); line3.setItem(i2); line3.setQuantity(1); // 1 Bread

            // No-discount total with lines
            var billLines = new GroceryBillWithLines(clerk2);
            billLines.add(line1);
            billLines.add(line2);
            billLines.add(line3);
            billLines.printReceipt();

            // Discount with lines (preferred = true)
            var dBillLinesPreferred = new DiscountBillWithLines(clerk2, preferred: true);
            dBillLinesPreferred.add(line1);
            dBillLinesPreferred.add(line2);
            dBillLinesPreferred.add(line3);
            dBillLinesPreferred.printReceipt();

            // Discount with lines (preferred = false)
            var dBillLinesNormal = new DiscountBillWithLines(clerk2, preferred: false);
            dBillLinesNormal.add(line1);
            dBillLinesNormal.add(line2);
            dBillLinesNormal.add(line3);
            dBillLinesNormal.printReceipt();

            Console.WriteLine("Demo complete. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
