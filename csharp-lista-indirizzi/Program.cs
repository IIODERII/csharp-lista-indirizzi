namespace csharp_lista_indirizzi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] texts = File.ReadAllLines("C://addresses.csv");
            List<Address> addresses = new List<Address>();

            for (int i = 1; i < texts.Length; i++)
            {
                string[] data = texts[i].Split(",");
                try
                {
                    foreach(string s in data)
                    {
                        if (s.Length == 0)
                            throw new MissingFieldException();
                    }
                   addresses.Add(new Address(data[0], data[1], data[2], data[3], data[4], int.Parse(data[5])));
                }
                catch (MissingFieldException e)
                {
                    Console.WriteLine("ATTENZIONE!! Sembra che alcuni campi non siano presenti!");
                }
                catch (Exception e) {
                    if(data.Length < 5)
                    {
                        Console.WriteLine("ATTENZIONE!! Sembra che alcuni campi non siano presenti!");
                    }else if (data[4].Length > 2)
                    {
                        Console.WriteLine("ATTENZIONE!! La provincia può contenere al massimo due lettere!");
                    }
                    else
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                
            }

            foreach(Address a in addresses)
            {
                Console.WriteLine($"\nNome: {a.Name},\nCognome: {a.Surname},\nVia: {a.Street},\nCittà: {a.City},\nProvincia: {a.Province},\nCAP: {a.ZIP}");
            }
        }
    }
}
