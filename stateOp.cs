    class Program
    {
        static void Main(string[] args)
        {
            // STATE PROGRAMLAMA 
            // NEDİR? NASIL YAPILIR?

            // Verilen string ifadede ki yan yana "11" olan durumu nasıl buluruz? 
            // İşte State işlemi burda devreye giriyor.

            int state = 0;
            string s = "101010000000001011";
            for (int i = 0; i < s.Length; i++)
            {   if (state == 0)
                    if (s[i] == '1') { state = 1; continue; }
                if (state == 1)
                    if (s[i] == '1') { state = 2; }
                    else state = 0;
            }

            //Yukarıdaki ifadenin daha açık bir şekilde yazılmış halide şu şekildedir:

            int[,] q = new int[3, 2]; //3 durumum 2 inputum var
            q[0, 1] = 1;
            q[1, 1] = 2;
            q[1, 0] = 0;
            q[2, 0] = 2;
            q[2, 1] = 2;

            state = 0;
            for (int i = 0; i < s.Length; i++)
            {
                state = q[state, (byte)s[i] - (byte)'0']; //ascii değerlerindeki 25-24 durumunu çıkarıp 1 i buluyoruz.
            }
            if (state == 2) Console.WriteLine("bulundu");
            else Console.WriteLine("bulunamadı");

            Console.WriteLine("-----------------------------------------------------------------------------------------------------------"); 


            //inputlarımız a..z ye kadar olsun (ingilizce alfabe ile) 
            //buradan "the" bulalım.

            state = 0;
            string a = "utuhuthuthhuththefruhfuhtt";
            int[,] t = new int[4, 26];
            t[0, (byte)'t'-(byte)'a'] = 1;

            t[1, (byte)'h' - (byte)'a'] = 2;
            t[1, (byte)'t' - (byte)'a'] = 1;

            t[2, (byte)'e' - (byte)'a'] = 3;
            t[2, (byte)'t' - (byte)'a'] = 1;

            for (int i = 0; i < 26; i++)
            {
                t[3, i] = 3; 
            }

            for (int i = 0; i < a.Length; i++)
            {
                state = t[state, (byte)a[i] - (byte)'a']; //ascii değerlerindeki 25-24 durumunu çıkarıp 1 i buluyoruz.
            }
            if (state == 3) Console.WriteLine("bulundu");
            else Console.WriteLine("bulunamadı");

           
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");


            //Bir örnek daha yapalım bu sefer aranan ifade st nin içinde, aradığımız yer f in içinde.

            int[,] y = new int[6, 26];
            state = 0;
            string f = "tuyrtuyrghghnkgfnfgenfgejfjhththth";
            string st = "uykuuy";

            for (int i = 0; i < st.Length; i++)
            {
                y[i, (byte)st[i] - (byte)'a'] = i + 1;
                //if (i != 0) y[i, (byte)st[i] - (byte)'a'] = 1;
            }
            for (int i = 1; i < st.Length-2; i++)
            {
                y[i, (byte)st[0] - (byte)'a'] = 1;
            }
            for (int i = 0; i < 26; i++)
            {
                y[5, i] = 5;
            }
            for (int i = 0; i < f.Length; i++)
            {
                state = y[state, (byte)f[i] - (byte)'a'];
            }
            if (state == 2) Console.WriteLine("bulundu");
            else Console.WriteLine("bulunamadı");

        }
    }
}