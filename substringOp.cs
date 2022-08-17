class Program
    {
        static void Main(string[] args)
        {   
            //SUBSTRING BULMA İŞLEMİ

            ///en uzun substring i bulmak 
            //lcs ---> longest common substring

            string s1 = "abcdefghjkl";
            string s2 = "01dabxfghab";
            int[,] lcs = new int[s1.Length, s2.Length];
            int eblcs = 0; //en büyük lcs
            for (int i = 0; i < s1.Length; i++)
            {
                for (int j = 0; j < s2.Length; j++)
                {
                    if (s1[i] == s2[j]) //matriste en sol kısımda sol çapraza bakamayacağımız durumu kurtarmak için
                    {
                        if (i == 0 || j == 0) 
                            lcs[i, j] = 1; 
                        
                        else
                            lcs[i, j] = lcs[i - 1, j - 1]+1;

                        if (eblcs < lcs[i, j]) eblcs = lcs[i, j];
                    }
                }
            }

            //12mum3aba44512321
            // SORU: En büyük düz ve tersten okunuşu yazılışı aynı olanı nasıl buluruz?



            //CEVAP:
            // İlk gerçekleştirdiğimiz substring işleminin aynısı sadece bu string ifadeyi tersten alıp dizideki sütun olacak.





            // longest common subsequence İŞLEMİ

            s1 = "0a12cc3v456x789";
            s2 = "a00c12c3vx333";
            eblcs = 0;
            for (int i = 0; i < s1.Length; i++)
            {
                for (int j = 0; j < s2.Length; j++)
                {
                    if (s1[i] == s2[j]) //matriste en sol kısımda sol çapraza bakamayacağımız durumu kurtarmak için
                    {
                        if (i == 0 || j == 0)
                            lcs[i, j] = 1;

                        else
                            lcs[i, j] = lcs[i - 1, j - 1] + 1;

                        if (eblcs < lcs[i, j]) eblcs = lcs[i, j];
                    }
                    else
                    {   
                        if(i==0||j==0)

                        // sınır değerler eklenecek onu da sizler yapın bakalım :)
                        if (lcs[i - 1, j] > lcs[i, j - 1])
                            lcs[i, j] = lcs[i - 1, j];
                        else lcs[i, j] = lcs[i, j - 1];
                    }
                }
            }
            
        }
    }