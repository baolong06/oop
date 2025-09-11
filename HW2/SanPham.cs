
internal class SanPham
{
    private string masp;
    private string tensp;
    private double giaban;
    private int soluongton;
    public SanPham(string masp, string tensp, double giaban, int slton)
    {
        this.masp = masp;
        this.tensp = tensp;
        this.giaban = giaban;
        this.soluongton = slton;
    }
    public void InSanPham()
    {
        Console.WriteLine("MaSP={0}, TenSP ={1}, Gia ban={2}, So luong con={3}", masp, tensp, giaban, soluongton);
    }
    public bool KiemTraDatHang(int thr)
    {
        return soluongton <thr;
    }
}

