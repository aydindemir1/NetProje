namespace NetProje.Delegate;

    delegate void MesajGonder(string mesaj);
    public class DelegateExample
    {
        // Delegemiz tarafından çağrılacak metotlar
        static void KonsolaYaz(string mesaj)
        {
            Console.WriteLine("Konsol: " + mesaj);
        }

        static void DosyayaYaz(string mesaj)
        {
            // Basitlik için dosyaya yazma işlevselliği eklendiğini varsayalım
            Console.WriteLine("Dosya: " + mesaj);
        }

        static void Main(string[] args)
        {
            // Delegemizi oluşturuyoruz
            MesajGonder mesajGonderDelegate = null;

            // Delegemize metotları atıyoruz
            mesajGonderDelegate += KonsolaYaz;
            mesajGonderDelegate += DosyayaYaz;

            // Delegemizi kullanarak metotları çağırıyoruz
            mesajGonderDelegate("Merhaba, delegeler!");

            // Delegemizden bir metodu kaldırabiliriz
            mesajGonderDelegate -= KonsolaYaz;

            // Tekrar çağırıyoruz, ancak artık KonsolaYaz metodu çağrılmayacak
            mesajGonderDelegate("Tekrar merhaba, delegeler!");
        }
    }


