namespace CounterApp
{
    public class CounterApp
    {
        public static void Main()
        {
            List<(string label, int as_second)> minutes_list = new List<(string label, int as_second)>
            {
                ("10 minutes", 10 * 60), ("20 minutes", 20 * 60), ("30 minutes", 30 * 60),
                ("40 minutes", 40 * 60), ("50 minutes", 50 * 60), ("60 minutes", 60 * 60),
                ("70 minutes", 70 * 60), ("90 minutes", 90 * 60), ("120 minutes", 120 * 60)
            };
            List<string> d_keys_list = new List<string>
            {
                "D1", "D2", "D3", "D4", "D5", "D6", "D7", "D8", "D9"
            };

            foreach (var (min, idx) in minutes_list.Select((m, i) => (m, i)))
            {
                Console.WriteLine($"{idx + 1} --> {min.label}");
            }
            Console.WriteLine("\r\r");
            Console.WriteLine("Please select a count minutes...");

            int selected = 0;
            while (true)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                string input = cki.Key.ToString();
                if (input == "Q") return;
                if (!d_keys_list.Contains(input)) continue;
                try
                {
                    selected = int.Parse(input[1].ToString());
                }
                catch (FormatException)
                {
                    continue;
                }
                if (1 <= selected && selected <= minutes_list.Count) break;
            }

            (string label, int as_second) target_min = minutes_list[--selected];
            for (int i = target_min.as_second; 0 <= i; i--)
            {
                Console.CursorLeft = 0;
                Console.Write("{0:D2}", i);
                Thread.Sleep(1000);
            }
        }
    }
}