using System;

// Event yayıncısı sınıfı
class Yayinci
{
    // Event tanımla
    public event EventHandler<MessageEventArgs> MesajGeldi;

    // Event tetikleyici metodu
    public void MesajGonder(string mesaj)
    {
        // Event'i tetikle ve mesajı iletecek bir olay argümanı oluştur
        MesajGeldi?.Invoke(this, new MessageEventArgs(mesaj));
    }
}

// Event argümanı sınıfı
public class MessageEventArgs : EventArgs
{
    public string Mesaj { get; }

    public MessageEventArgs(string mesaj)
    {
        Mesaj = mesaj;
    }
}

// Event abonesi sınıfı
class Abone
{
    public void MesajAlindi(object sender, MessageEventArgs e)
    {
        Console.WriteLine("Mesaj Alındı: " + e.Mesaj);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Yayinci yayinci = new Yayinci();
        Abone abone1 = new Abone();
        Abone abone2 = new Abone();

        // Event'e abone ol
        yayinci.MesajGeldi += abone1.MesajAlindi;
        yayinci.MesajGeldi += abone2.MesajAlindi;

        // Yayıncıdan mesaj gönder
        yayinci.MesajGonder("Merhaba!");

        // Bir aboneyi kaldır
        yayinci.MesajGeldi -= abone2.MesajAlindi;

        // Yayıncıdan başka bir mesaj gönder
        yayinci.MesajGonder("Nasılsınız?");
    }
}

