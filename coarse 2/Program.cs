using System.Text.RegularExpressions;

internal class Program
{
    const string dataBaseDevice = "data device.txt";
    const string dataBaseCountry = "countries.txt";
    const string dataBaseGenre = "genres.txt";
    const string dataBaseType = "types.txt";
    struct Device
    {
        public int idDevice;
        public int idType;
        public string film;
        public int idCountry;
        public int idGenre;
        public int filmNumber;
        public string timespan;
        public string purchaseWay;
        public string date;
        public string owner;
        public string note;
    }
    static Device[] InputDevice() //in & output
    {
        string[] l = File.ReadAllLines(dataBaseDevice);
        Device[] c = new Device[l.Length];
        for (int i = 0; i < c.Length; i++)
        {
            string[] data = l[i].Split(';');
            c[i] = CreateDevice(Convert.ToInt32(data[0].Trim()), Convert.ToInt32(data[1].Trim()), data[2], Convert.ToInt32(data[3].Trim()), Convert.ToInt32(data[4].Trim()), Convert.ToInt32(data[5].Trim()), data[6], data[7], data[8], data[9], data[10]);
        }
        return c;
    }
    static string[] InputCountryOrGenreOrType(string dataBase)
    {
        string[] l = File.ReadAllLines(dataBase);
        string[] c = new string[l.Length];
        for (int i = 0; i < c.Length; i++)
        {
            c[i] = l[i];
        }
        return c;
    }
    static string IdIntoString(string[] a, int id)
    {
        --id;
        string s = a[id];
        return s;
    }
    static void OutputDevice(Device[] a, string[] c, string[] t, string[] g)
    {
        int i = 1;
        foreach (var device in a)
        {
            string type = IdIntoString(t, device.idType);
            string country = IdIntoString(c, device.idCountry);
            string genre = IdIntoString(g, device.idGenre);
            Console.WriteLine($"{i})id - {device.idDevice}\tType - {type}\tFilm - {device.film}\tCountry - {country}\tGenre - {genre}\tFilm number - {device.filmNumber}\tTime - {device.timespan}\tPurchase - {device.purchaseWay}\tDate - {device.date}\tOwner - {device.owner}\tNote - {device.note}");
            ++i;
        }
    }
    static void OutputCountryOrGenreOrType(string[] a)
    {
        int i = 1;
        foreach (var obj in a)
        {
            Console.WriteLine($"{i}){obj}");
            ++i;
        }
    }
    static Device CreateDevice(int id, int t, string f, int c, int g, int fn, string ts, string pw, string d, string o, string n)
    {
        Device dev = new Device();
        dev.idDevice = id;
        dev.idType = t;
        dev.film = f;
        dev.idCountry = c;
        dev.idGenre = g;
        dev.filmNumber = fn;
        dev.timespan = ts;
        dev.purchaseWay = pw;
        dev.date = d;
        dev.owner = o;
        dev.note = n;
        return dev;
    }
    static string[] EnterSortChoices()//sorts
    {
        string[] sortChoices;
        List<string> sortChoicesList = new List<string>();
        while (true)
        {
            string sortChoice = ChoiceCheckEdit(5);
            if (string.IsNullOrEmpty(sortChoice))
            {
                sortChoices = sortChoicesList.ToArray();
                break;
            }
            if (sortChoice == "1")
            {
                sortChoicesList.Add("film");
            }
            if (sortChoice == "2")
            {
                sortChoicesList.Add("country");
            }
            if (sortChoice == "3")
            {
                sortChoicesList.Add("genre");
            }
            if (sortChoice == "4")
            {
                sortChoicesList.Add("filmNumber");
            }
            if (sortChoice == "5")
            {
                sortChoicesList.Add("date");
            }
        }
        return sortChoices;
    }
    static Device[] SortDevice(Device[] d, string[] sortChoices)
    {
        IOrderedEnumerable<Device> sortedDevice = null; //sort in sort

        foreach (var choice in sortChoices)
        {
            switch (choice)
            {
                case "film":
                    if (sortedDevice == null)
                    {
                        sortedDevice = d.OrderBy(m => m.film);
                    }
                    else
                    {
                        sortedDevice = sortedDevice.ThenBy(m => m.film);
                    }
                    break;
                case "country":
                    if (sortedDevice == null)
                    {
                        sortedDevice = d.OrderBy(m => m.idCountry);
                    }
                    else
                    {
                        sortedDevice = sortedDevice.ThenBy(m => m.idCountry);
                    }
                    break;
                case "genre":
                    if (sortedDevice == null)
                    {
                        sortedDevice = d.OrderBy(m => m.idGenre);
                    }
                    else
                    {
                        sortedDevice = sortedDevice.ThenBy(m => m.idGenre);
                    }
                    break;
                case "filmNumber":
                    if (sortedDevice == null)
                    {
                        sortedDevice = d.OrderBy(m => m.filmNumber);
                    }
                    else
                    {
                        sortedDevice = sortedDevice.ThenBy(m => m.filmNumber);
                    }
                    break;
                case "date":
                    if (sortedDevice == null)
                    {
                        sortedDevice = d.OrderBy(m => m.date);
                    }
                    else
                    {
                        sortedDevice = sortedDevice.ThenBy(m => m.date);
                    }
                    break;
            }
        }
        if (sortedDevice == null)
        {
            return d;
        }
        d = sortedDevice?.ToArray();
        return d;
    }
    static Device[] InputDataDevice(Device[] a, string[] t, string[] c, string[] g) //create
    {
        int id = EnterIdDevice(a);
        OutputCountryOrGenreOrType(t);
        Console.Write("Type - "); //list
        int it = ChoiceCheck(t.Length);
        Console.Clear();
        Console.Write("Film - ");
        string f = EnterFilm();
        OutputCountryOrGenreOrType(c);
        Console.Write("Country - "); //list
        int ic = ChoiceCheck(c.Length);
        Console.Clear();
        OutputCountryOrGenreOrType(g);
        Console.Write("Genre - "); //list
        int ig = ChoiceCheck(g.Length);
        Console.Clear();
        Console.Write("Film number - ");
        int fn = ChoiceCheck(100000);
        Console.Write("Timespan (min) - ");
        string ts = EnterTimespan();
        Console.Write("Purchase way - ");
        string pw = EnterString();
        Console.Write("Date - ");
        string d = EnterDate();
        Console.Write("Owner - ");
        string o = EnterOwner();
        Console.Write("Note - ");
        string n = EnterString();

        Device dev = CreateDevice(id, it, f, ic, ig, fn, ts, pw, d, o, n);
        Array.Resize(ref a, a.Length + 1);
        a[a.Length - 1] = dev;
        return a;
    }
    static string EnterTimespan()
    {
        int num = ChoiceCheck(1000000);
        string ts = num.ToString() + "min";
        return ts;
    }
    static string EnterString()
    {
        string type = Convert.ToString(Console.ReadLine());
        while (string.IsNullOrEmpty(type))
        {
            Console.Write("ERROR! This format isn't empty. Enter again - ");
            type = Convert.ToString(Console.ReadLine());
        }
        return type;
    }
    static int EnterIdDevice(Device[] a)
    {
        int i = a[a.Length - 1].idDevice + 1;
        return i;
    }
    static string EnterOwner()
    {
        string n = Convert.ToString(Console.ReadLine());
        string pattern = "^[A-Z][a-z]* [A-Z][a-z]*$"; //name+surename
        while (!Regex.IsMatch(n, pattern))
        {
            Console.Write("ERROR! Name mustn't include digits or start with a lower case letter. Enter again - ");
            n = Convert.ToString(Console.ReadLine());
        }
        return n;
    }
    static string EnterCountryOrGenre()
    {
        string t = Convert.ToString(Console.ReadLine());
        string pattern = "^[A-Z][a-z]*$";
        while (!Regex.IsMatch(t, pattern))
        {
            Console.Write("ERROR! Country or genre mustn't include digits or start with a lower case letter. Enter again - ");
            t = Convert.ToString(Console.ReadLine());
        }
        return t;
    }
    static string EnterFilm()
    {
        string p = Convert.ToString(Console.ReadLine());
        string pattern = @"^[A-Z][a-zA-Z0-9s]*$";
        while (!Regex.IsMatch(p, pattern))
        {
            Console.Write("ERROR! Film starts with upper case. Enter again - ");
            p = Convert.ToString(Console.ReadLine());
        }
        return p;
    }
    static string[] CreateCountry(string[] a)
    {
        Console.Write("New country - ");
        string c = EnterCountryOrGenre();

        Array.Resize(ref a, a.Length + 1);
        a[a.Length - 1] = c;
        return a;
    }
    static string[] CreateGenre(string[] a)
    {
        Console.Write("New genre - ");
        string c = EnterCountryOrGenre();

        Array.Resize(ref a, a.Length + 1);
        a[a.Length - 1] = c;
        return a;
    }
    static string[] CreateType(string[] a)
    {
        Console.Write("New type - ");
        string c = EnterString();

        Array.Resize(ref a, a.Length + 1);
        a[a.Length - 1] = c;
        return a;
    }
    static int ChoiceCheck(int limit)
    {
        int i;
        while (!int.TryParse(Console.ReadLine(), out i) || i < 1 || i > limit)
        {
            Console.Write("ERROR! Enter again - ");
        }
        return i;
    }
    static string EnterDate()
    {
        string t = Convert.ToString(Console.ReadLine());
        string pattern = @"^(0[1-9]|[12][0-9]|3[01])\.(0[1-9]|1[0-2])\.\d{2}$"; // \. dot read as a character; 01-31 day; 01-12 month; 2-digit year
        while (!Regex.IsMatch(t, pattern))
        {
            Console.Write("ERROR! Date format is (dd.mm.yy). Enter again - ");
            t = Convert.ToString(Console.ReadLine());
        }
        return t;
    }
    static Device[] EditDevice(Device[] a, string[] t, string[] c, string[] g, int i) //edit
    {
        --i;
        OutputCountryOrGenreOrType(t);
        string l = ChoiceCheckEdit(t.Length);
        Console.Write("Type - ");
        int type = EditTypeDevice(a, l, i);
        Console.Clear();
        Console.Write("Film - ");
        string f = EditFilm(a, i);
        OutputCountryOrGenreOrType(c);
        Console.Write("Country - ");
        string l1 = ChoiceCheckEdit(c.Length);
        int country = EditCountryDevice(a, l1, i);
        Console.Clear();
        OutputCountryOrGenreOrType(g);
        Console.Write("Genre - ");
        string l2 = ChoiceCheckEdit(g.Length);
        int genre = EditGenreDevice(a, l2, i);
        Console.Clear();
        Console.Write("Film number - ");
        int fn = EditFilmNumber(a, i);
        Console.Write("Timespan (min) - ");
        string ts = EditTimespan(a, i);
        Console.Write("Purchase way - ");
        string pw = EditPurchaseWay(a, i);
        Console.Write("Date - ");
        string d = EditDate(a, i);
        Console.Write("Owner - ");
        string o = EditOwner(a, i);
        Console.Write("Note - ");
        string n = EditNote(a, i);

        Device dev = CreateDevice(a[i].idDevice, type, f, country, genre, fn, ts, pw, d, o, n);
        a[i] = dev;
        return a;
    }
    static int EditTypeDevice(Device[] a, string l, int i)
    {
        int t;
        if (!string.IsNullOrEmpty(l))
        {
            i = Convert.ToInt32(l);
            t = i;
            return t;
        }
        t = a[i].idType;
        return t;
    }
    static int EditCountryDevice(Device[] a, string l, int i)
    {
        int s;
        if (!string.IsNullOrEmpty(l))
        {
            i = Convert.ToInt32(l);
            s = i;
            return s;
        }
        s = a[i].idCountry;
        return s;
    }
    static int EditGenreDevice(Device[] a, string l, int i)
    {
        int s;
        if (!string.IsNullOrEmpty(l))
        {
            i = Convert.ToInt32(l);
            s = i;
            return s;
        }
        s = a[i].idGenre;
        return s;
    }
    static string EnterOwnerEdit()
    {
        string? n = Convert.ToString(Console.ReadLine());
        string pattern = "^[A-Z][a-z]* [A-Z][a-z]*$"; //name+surename
        if (!string.IsNullOrEmpty(n))
        {
            while (!Regex.IsMatch(n, pattern))
            {
                Console.Write("ERROR! Name mustn't include digits or start with a lower case letter. Enter again - ");
                n = Convert.ToString(Console.ReadLine());
            }
            return n;
        }
        return n;
    }
    static string EditOwner(Device[] a, int i)
    {
        string? n = EnterOwnerEdit();
        if (string.IsNullOrEmpty(n))
        {
            n = a[i].owner;
        }
        return n;
    }
    static string EditFilm(Device[] a, int i)
    {
        string? n = Convert.ToString(Console.ReadLine());
        if (string.IsNullOrEmpty(n))
        {
            n = a[i].film;
        }
        return n;
    }
    static int EditFilmNumber(Device[] a, int i)
    {
        string? n = ChoiceCheckEdit(10000000);
        int l;
        if (string.IsNullOrEmpty(n))
        {
            l = a[i].filmNumber;
            return l;
        }
        l = Convert.ToInt32(n);
        return l;
    }
    static string EnterTimespanEdit()
    {
        string? n = ChoiceCheckEdit(1000000);
        if (!string.IsNullOrEmpty(n))
        {
            string ts = n + "min";
        }
        return n;
    }
    static string EditTimespan(Device[] a, int i)
    {
        string? n = EnterTimespanEdit();
        if (string.IsNullOrEmpty(n))
        {
            n = a[i].timespan;
        }
        return n;
    }
    static string EditPurchaseWay(Device[] a, int i)
    {
        string? n = Convert.ToString(Console.ReadLine());
        if (string.IsNullOrEmpty(n))
        {
            n = a[i].purchaseWay;
        }
        return n;
    }
    static string EditNote(Device[] a, int i)
    {
        string? n = Convert.ToString(Console.ReadLine());
        if (string.IsNullOrEmpty(n))
        {
            n = a[i].note;
        }
        return n;
    }
    static string EnterCountryEdit()
    {
        string? n = Convert.ToString(Console.ReadLine());
        string pattern = "^[A-Z][a-z]*$";
        if (!string.IsNullOrEmpty(n))
        {
            while (!Regex.IsMatch(n, pattern))
            {
                Console.Write("ERROR! Country mustn't include digits or start with a lower case letter. Enter again - ");
                n = Convert.ToString(Console.ReadLine());
            }
        }
        return n;
    }
    static string EnterStringEdit()
    {
        string? type = Convert.ToString(Console.ReadLine());
        string pattern = @"^[^d]+$";//no digits
        if (!string.IsNullOrEmpty(type))
        {
            while (!Regex.IsMatch(type, pattern))
            {
                Console.Write("ERROR! The format mustn't include digits. Enter again - ");
                type = Convert.ToString(Console.ReadLine());
            }
        }
        return type;
    }
    static string[] EditCountry(string[] a, int i)
    {
        --i;
        string? n = EnterCountryEdit();
        if (string.IsNullOrEmpty(n))
        {
            n = a[i];
        }
        a[i] = n;
        return a;
    }
    static string[] EditGenreOrType(string[] a, int i)
    {
        --i;
        string? n = EnterStringEdit();
        if (string.IsNullOrEmpty(n))
        {
            n = a[i];
        }
        a[i] = n;
        return a;
    }
    static string ChoiceCheckEdit(int limit)
    {
        string? i = Convert.ToString(Console.ReadLine());
        if (!string.IsNullOrEmpty(i))
        {
            int l;
            while (!int.TryParse(i, out l) || l < 1 || l > limit)
            {
                Console.Write("ERROR! Enter again - ");
                i = Convert.ToString(Console.ReadLine());
            }
        }
        return i;
    }
    static string EnterDateEdit()
    {
        string? n = Convert.ToString(Console.ReadLine());
        string pattern = @"^(0[1-9]|[12][0-9]|3[01])\.(0[1-9]|1[0-2])\.\d{2}$"; // \. dot read as a character; 01-31 day; 01-12 month; 2-digit year
        if (!string.IsNullOrEmpty(n))
        {
            while (!Regex.IsMatch(n, pattern))
            {
                Console.Write("ERROR! Date format is (dd.mm.yy). Enter again - ");
                n = Convert.ToString(Console.ReadLine());
            }
        }
        return n;
    }
    static string EditDate(Device[] a, int i)
    {
        string? n = EnterDateEdit();
        if (string.IsNullOrEmpty(n))
        {
            n = a[i].date;
        }
        return n;
    }
    static Device[] DeleteCountryFromDevice(Device[] a, int i) //delete
    {
        List<Device> ol = new List<Device>();
        for (int j = 0; j < a.Length; ++j)
        {
            if (a[j].idCountry != i)
            {
                ol.Add(a[j]);
            }
        }
        Device[] a1 = ol.ToArray();
        return a1;
    }
    static Device[] DeleteGenreFromDevice(Device[] a, int i)
    {
        List<Device> ol = new List<Device>();
        for (int j = 0; j < a.Length; ++j)
        {
            if (a[j].idGenre != i)
            {
                ol.Add(a[j]);
            }
        }
        Device[] a1 = ol.ToArray();
        return a1;
    }
    static Device[] DeleteTypeFromDevice(Device[] a, int i)
    {
        List<Device> ol = new List<Device>();
        for (int j = 0; j < a.Length; ++j)
        {
            if (a[j].idType != i)
            {
                ol.Add(a[j]);
            }
        }
        Device[] a1 = ol.ToArray();
        return a1;
    }
    static Device[] DeleteDevice(Device[] a, int i)
    {
        i--;
        Device[] a1 = new Device[a.Length - 1];
        int k = 0;
        for (int j = 0; j < a.Length; ++j)
        {
            if (a[j].idDevice != a[i].idDevice)
            {
                a1[k] = a[j];
                ++k;
            }
        }
        return a1;
    }
    static string[] DeleteCountryOrGenreOrType(string[] a, int i)
    {
        i--;
        string[] a1 = new string[a.Length - 1];
        int k = 0;
        for (int j = 0; j < a.Length; ++j)
        {
            if (a[j] != a[i])
            {
                a1[k] = a[j];
                ++k;
            }
        }
        return a1;
    }
    static void SaveDevice(Device[] c) //save
    {
        using (StreamWriter sw = new StreamWriter(dataBaseDevice, false))
        {
            foreach (var h in c)
            {
                sw.WriteLine($"{h.idDevice};{h.idType};{h.film};{h.idCountry};{h.idGenre};{h.filmNumber};{h.timespan};{h.purchaseWay};{h.date};{h.owner};{h.note}");
            }
        }
    }
    static void SaveTypeOrCountryOrGenre(string[] a, string dataBase)
    {
        using (StreamWriter sw = new StreamWriter(dataBase, false))
        {
            foreach (var h in a)
            {
                sw.WriteLine($"{h}");
            }
        }
    }
    static void SaveReportFilmsByGenre(Device[] d, string[] g, string[] c, string[] t, string reportFile)
    {
        string[] sc = { "genre", "film" };
        d = SortDevice(d, sc);
        using (StreamWriter sw = new StreamWriter(reportFile, false))
        {
            for (int i = 0; i < g.Length; ++i)
            {
                int count = 0;
                sw.WriteLine($"{g[i]}");
                for (int j = 0; j < d.Length; ++j)
                {
                    if (d[j].idGenre == i + 1)
                    {
                        ++count;
                        string type = IdIntoString(t, d[j].idType);
                        string country = IdIntoString(c, d[j].idCountry);
                        sw.WriteLine($"{count};{d[j].film};{country};{type}");
                    }
                }
            }
        }
    }
    static void SaveReportFilmNumberByTypeGenre(Device[] d, string[] g, string[] t, string reportFile)
    {
        string[] sc = { "genre", "filmNumber" };
        d = SortDevice(d, sc);
        using (StreamWriter sw = new StreamWriter(reportFile, false))
        {
            for (int i = 0; i < t.Length; ++i)
            {
                int count = 0;
                int total = 0;
                sw.WriteLine($"{t[i]}");
                for (int j = 0; j < d.Length; ++j)
                {
                    if (d[j].idType == i + 1)
                    {
                        ++count;
                        total += d[j].filmNumber;
                        string genre = IdIntoString(g, d[j].idGenre);
                        sw.WriteLine($"{count};{genre};{d[j].filmNumber}");
                    }
                }
                sw.WriteLine($"{total}");
            }
        }
    }
    static void SaveReportFilmsByOwner(Device[] d, string[] c, string[] t, string reportFile)
    {
        string[] sc = { "owner", "film" };
        d = SortDevice(d, sc);
        string[] o = OwnerArray(d);
        using (StreamWriter sw = new StreamWriter(reportFile, false))
        {
            for (int i = 0; i < o.Length; ++i)
            {
                int count = 0;
                sw.WriteLine($"{o[i]}");
                for (int j = 0; j < d.Length; ++j)
                {
                    if (d[j].owner == o[i])
                    {
                        ++count;
                        string country = IdIntoString(c, d[j].idCountry);
                        string type = IdIntoString(t, d[j].idType);
                        sw.WriteLine($"{count};{d[j].film};{country};{type}");
                    }
                }
            }
        }
    }
    static void SaveReportDeviceOverOneFilm(Device[] d, string[] c, string[] t, string reportFile)
    {
        string[] sc = { "country", "film", "filmNumber" };
        d = SortDevice(d, sc);
        using (StreamWriter sw = new StreamWriter(reportFile, false))
        {
            for (int i = 0; i < t.Length; ++i)
            {
                int count = 0;
                sw.WriteLine($"{t[i]}");
                for (int j = 0; j < d.Length; ++j)
                {
                    if (d[j].idType == i + 1 && d[j].filmNumber > 1)
                    {
                        ++count;
                        string country = IdIntoString(c, d[j].idCountry);
                        sw.WriteLine($"{count};{d[j].film};{country};{d[j].filmNumber}");
                    }
                }
            }
        }
    }
    static Device[] FiltrationByType(Device[] d, int type) //filt
    {
        List<Device> dl = new List<Device>();
        foreach (var dev in d)
        {
            if (dev.idDevice == type)
            {
                dl.Add(dev);
            }
        }
        Device[] d1 = dl.ToArray();
        return d1;
    }
    static Device[] FiltrationByGenre(Device[] d, int genre)
    {
        List<Device> dl = new List<Device>();
        foreach (var dev in d)
        {
            if (dev.idGenre == genre)
            {
                dl.Add(dev);
            }
        }
        Device[] d1 = dl.ToArray();
        return d1;
    }
    static string[] FilmArray(Device[] d)
    {
        HashSet<string> fh = new HashSet<string>();
        foreach (var dev in d)
        {
            fh.Add(dev.film);
        }
        string[] f = new string[fh.Count];
        fh.CopyTo(f);
        return f;
    }
    static void FilmList(Device[] d, out string[] films)
    {
        films = FilmArray(d);
        int i = 1;
        foreach (var f in films)
        {
            Console.WriteLine($"{i}){f}");
            ++i;
        }
    }
    static Device[] FiltrationByFilm(Device[] d, int i, string[] films)
    {
        --i;
        List<Device> dl = new List<Device>();
        foreach (var dev in d)
        {
            if (dev.film == films[i])
            {
                dl.Add(dev);
            }
        }
        Device[] d1 = dl.ToArray();
        return d1;
    }
    static string[] OwnerArray(Device[] d)
    {
        HashSet<string> fh = new HashSet<string>();
        foreach (var dev in d)
        {
            fh.Add(dev.owner);
        }
        string[] f = new string[fh.Count];
        fh.CopyTo(f);
        return f;
    }
    static void OwnerList(Device[] d, out string[] owners)
    {
        owners = OwnerArray(d);
        int i = 1;
        foreach (var f in owners)
        {
            Console.WriteLine($"{i}){f}");
            ++i;
        }
    }
    static Device[] FiltrationByOwner(Device[] d, int i, string[] owners)
    {
        --i;
        List<Device> dl = new List<Device>();
        foreach (var dev in d)
        {
            if (dev.owner == owners[i])
            {
                dl.Add(dev);
            }
        }
        Device[] d1 = dl.ToArray();
        return d1;
    }
    static void OptionFilmsByGenre(Device[] d,string[] c, string[] t, string[] g)
    {
        string[] sc = { "genre", "film" };
        d = SortDevice(d,sc);
        for (int i=0;i<g.Length;++i)
        {
            int count = 0;
            Console.WriteLine($"{g[i]}");
            for (int j = 0; j < d.Length; ++j)
            {
                if (d[j].idGenre == i+1)
                {
                    ++count;
                    string type = IdIntoString(t, d[j].idType);
                    string country = IdIntoString(c, d[j].idCountry);
                    Console.WriteLine($"{count})Film - {d[j].film}\tCountry - {country}\tType - {type}");
                }
            }
        }
    }
    static void OptionFilmNumberByTypeGenre(Device[] d, string[] t, string[] g)
    {
        string[] sc = { "genre", "filmNumber" };
        d = SortDevice(d, sc);
        for (int i = 0; i < t.Length; ++i)
        {
            int count = 0;
            int total = 0;
            Console.WriteLine($"{t[i]}");
            for (int j = 0; j < d.Length; ++j)
            {
                if (d[j].idType == i + 1)
                {
                    ++count;
                    total += d[j].filmNumber;
                    string genre = IdIntoString(g, d[j].idGenre);
                    Console.WriteLine($"{count})Genre - {genre}\tFilmNumber - {d[j].filmNumber}");
                }
            }
            Console.WriteLine($"\tTotal film number - {total}");
        }
    }
    static void OptionFilmsByOwner(Device[] d, string[] c, string[] t)
    {
        string[] sc = { "owner", "film" };
        d = SortDevice(d, sc);
        string[] o = OwnerArray(d);
        for (int i = 0; i < o.Length; ++i)
        {
            int count = 0;
            Console.WriteLine($"{o[i]}");
            for (int j = 0; j < d.Length; ++j)
            {
                if (d[j].owner == o[i])
                {
                    ++count;
                    string country = IdIntoString(c, d[j].idCountry);
                    string type = IdIntoString(t, d[j].idType);
                    Console.WriteLine($"{count})Film - {d[j].film}\tCountry - {country}\tType - {type}");
                }
            }
        }
    }
    static void OptionDeviceOverOneFilm(Device[] d, string[] c, string[] t)
    {
        string[] sc = { "country", "film", "filmNumber" };
        d = SortDevice(d, sc);
        for (int i = 0; i < t.Length; ++i)
        {
            int count = 0;
            Console.WriteLine($"{t[i]}");
            for (int j = 0; j < d.Length; ++j)
            {
                if (d[j].idType == i+1 && d[j].filmNumber>1)
                {
                    ++count;
                    string country = IdIntoString(c, d[j].idCountry);
                    Console.WriteLine($"{count})Film - {d[j].film}\tCountry - {country}\tFilm number - {d[j].filmNumber}");
                }
            }
        }
    }
    private static void Main(string[] args)
    {
        if (File.Exists(dataBaseDevice) && File.Exists(dataBaseCountry) && File.Exists(dataBaseGenre) && File.Exists(dataBaseType))
        {
            Device[] d = InputDevice(); Device[] d1;
            string[] c = InputCountryOrGenreOrType(dataBaseCountry); string[] c1;
            string[] g = InputCountryOrGenreOrType(dataBaseGenre); string[] g1;
            string[] t = InputCountryOrGenreOrType(dataBaseType); string[] t1;

            int choice;
            string sortChoice;
            string[] sortChoices;
            bool flag, flag1, flag2;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\t! W E L C O M E !");
                Console.WriteLine("Please, pick a mode or complete the programm:");
                Console.WriteLine("1)Admin");
                Console.WriteLine("2)User");
                Console.WriteLine("3)Advanced option");
                Console.WriteLine("4)Exit");
                choice = ChoiceCheck(4);
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        flag = true;
                        while (flag)
                        {
                            Console.Clear();
                            Console.WriteLine("\t- Admin mode. Please, pick an option from the list:");
                            Console.WriteLine("1)Create");
                            Console.WriteLine("2)Delete");
                            Console.WriteLine("3)Edit");
                            Console.WriteLine("4)Back");
                            choice = ChoiceCheck(4);
                            Console.Clear();
                            switch (choice)
                            {
                                case 1:
                                    flag1 = true;
                                    while (flag1)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("\t- Admin mode. Create option");
                                        Console.WriteLine("Please, pick an object:");
                                        Console.WriteLine("1)Device");
                                        Console.WriteLine("2)Country");
                                        Console.WriteLine("3)Genre");
                                        Console.WriteLine("4)Type");
                                        Console.WriteLine("5)Back");
                                        choice = ChoiceCheck(5);
                                        Console.Clear();
                                        switch (choice)
                                        {
                                            case 1:
                                                Console.WriteLine("\t- Admin mode. Create a device");
                                                d1 = InputDataDevice(d, t, c, g);
                                                Console.Clear();
                                                Console.WriteLine("The device created successfully");
                                                Console.WriteLine("Wish to save the change into the the data base?");
                                                flag2 = true;
                                                while (flag2)
                                                {
                                                    Console.WriteLine("1)yes");
                                                    Console.WriteLine("2)no");
                                                    choice = ChoiceCheck(2);
                                                    Console.Clear();
                                                    switch (choice)
                                                    {
                                                        case 1:
                                                            SaveDevice(d1);
                                                            Console.WriteLine("The change saved successfully");
                                                            Console.WriteLine("Press ENTER to continue");
                                                            Console.ReadLine();
                                                            flag2 = false;
                                                            break;
                                                        case 2:
                                                            flag2 = false;
                                                            continue;
                                                    }
                                                }
                                                break;
                                            case 2:
                                                Console.WriteLine("\t- Admin mode. Create a country");
                                                c1 = CreateCountry(c);
                                                Console.Clear();
                                                Console.WriteLine("The country created successfully");
                                                Console.WriteLine("Wish to save the change into the the data base?");
                                                flag2 = true;
                                                while (flag2)
                                                {
                                                    Console.WriteLine("1)yes");
                                                    Console.WriteLine("2)no");
                                                    choice = ChoiceCheck(2);
                                                    Console.Clear();
                                                    switch (choice)
                                                    {
                                                        case 1:
                                                            SaveTypeOrCountryOrGenre(c1, dataBaseCountry);
                                                            Console.WriteLine("The change saved successfully");
                                                            Console.WriteLine("Press ENTER to continue");
                                                            Console.ReadLine();
                                                            flag2 = false;
                                                            break;
                                                        case 2:
                                                            flag2 = false;
                                                            continue;
                                                    }
                                                }
                                                break;
                                            case 3:
                                                Console.WriteLine("\t- Admin mode. Create a genre");
                                                g1 = CreateGenre(g);
                                                Console.Clear();
                                                Console.WriteLine("The genre created successfully");
                                                Console.WriteLine("Wish to save the change into the the data base?");
                                                flag2 = true;
                                                while (flag2)
                                                {
                                                    Console.WriteLine("1)yes");
                                                    Console.WriteLine("2)no");
                                                    choice = ChoiceCheck(2);
                                                    Console.Clear();
                                                    switch (choice)
                                                    {
                                                        case 1:
                                                            SaveTypeOrCountryOrGenre(g1, dataBaseGenre);
                                                            Console.WriteLine("The change saved successfully");
                                                            Console.WriteLine("Press ENTER to continue");
                                                            Console.ReadLine();
                                                            flag2 = false;
                                                            break;
                                                        case 2:
                                                            flag2 = false;
                                                            continue;
                                                    }
                                                }
                                                break;
                                            case 4:
                                                Console.WriteLine("\t- Admin mode. Create a type");
                                                t1 = CreateType(t);
                                                Console.Clear();
                                                Console.WriteLine("The type created successfully");
                                                Console.WriteLine("Wish to save the change into the the data base?");
                                                flag2 = true;
                                                while (flag2)
                                                {
                                                    Console.WriteLine("1)yes");
                                                    Console.WriteLine("2)no");
                                                    choice = ChoiceCheck(2);
                                                    Console.Clear();
                                                    switch (choice)
                                                    {
                                                        case 1:
                                                            SaveTypeOrCountryOrGenre(t1, dataBaseType);
                                                            Console.WriteLine("The change saved successfully");
                                                            Console.WriteLine("Press ENTER to continue");
                                                            Console.ReadLine();
                                                            flag2 = false;
                                                            break;
                                                        case 2:
                                                            flag2 = false;
                                                            continue;
                                                    }
                                                }
                                                break;
                                            case 5:
                                                flag1 = false;
                                                continue;
                                        }
                                    }
                                    break;
                                case 2:
                                    flag1 = true;
                                    while (flag1)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("\t- Admin mode. Delete option");
                                        Console.WriteLine("Please, pick an object:");
                                        Console.WriteLine("1)Device");
                                        Console.WriteLine("2)Country");
                                        Console.WriteLine("3)Genre");
                                        Console.WriteLine("4)Type");
                                        Console.WriteLine("5)Back");
                                        choice = ChoiceCheck(5);
                                        Console.Clear();
                                        switch (choice)
                                        {
                                            case 1:
                                                Console.WriteLine("\t- Admin mode. Delete a device");
                                                Console.WriteLine("Please, pick a device:");
                                                OutputDevice(d,c,t,g);
                                                choice = ChoiceCheck(d.Length);
                                                d1 = DeleteDevice(d, choice);
                                                Console.Clear();
                                                Console.WriteLine("The device's history erased successfully");
                                                Console.WriteLine("Wish to save the change into the the data base?");
                                                flag2 = true;
                                                while (flag2)
                                                {
                                                    Console.WriteLine("1)yes");
                                                    Console.WriteLine("2)no");
                                                    choice = ChoiceCheck(2);
                                                    Console.Clear();
                                                    switch (choice)
                                                    {
                                                        case 1:
                                                            SaveDevice(d1);
                                                            Console.WriteLine("The change saved successfully");
                                                            Console.WriteLine("Press ENTER to continue");
                                                            Console.ReadLine();
                                                            flag2 = false;
                                                            break;
                                                        case 2:
                                                            flag2 = false;
                                                            continue;
                                                    }
                                                }
                                                break;
                                            case 2:
                                                Console.WriteLine("\t- Admin mode. Delete a country");
                                                Console.WriteLine("Please, pick a country:");
                                                OutputCountryOrGenreOrType(c);
                                                choice = ChoiceCheck(c.Length);
                                                c1 = DeleteCountryOrGenreOrType(c, choice);
                                                d1 = DeleteCountryFromDevice(d, choice);
                                                Console.Clear();
                                                Console.WriteLine("The country's history erased successfully");
                                                Console.WriteLine("Wish to save the change into the the data base?");
                                                flag2 = true;
                                                while (flag2)
                                                {
                                                    Console.WriteLine("1)yes");
                                                    Console.WriteLine("2)no");
                                                    choice = ChoiceCheck(2);
                                                    Console.Clear();
                                                    switch (choice)
                                                    {
                                                        case 1:
                                                            SaveTypeOrCountryOrGenre(c1, dataBaseCountry);
                                                            SaveDevice(d1);
                                                            Console.WriteLine("The change saved successfully");
                                                            Console.WriteLine("Press ENTER to continue");
                                                            Console.ReadLine();
                                                            flag2 = false;
                                                            break;
                                                        case 2:
                                                            flag2 = false;
                                                            continue;
                                                    }
                                                }
                                                break;
                                            case 3:
                                                Console.WriteLine("\t- Admin mode. Delete a genre");
                                                Console.WriteLine("Please, pick a genre:");
                                                OutputCountryOrGenreOrType(g);
                                                choice = ChoiceCheck(g.Length);
                                                g1 = DeleteCountryOrGenreOrType(g, choice);
                                                d1 = DeleteGenreFromDevice(d, choice);
                                                Console.Clear();
                                                Console.WriteLine("The genre's history erased successfully");
                                                Console.WriteLine("Wish to save the change into the the data base?");
                                                flag2 = true;
                                                while (flag2)
                                                {
                                                    Console.WriteLine("1)yes");
                                                    Console.WriteLine("2)no");
                                                    choice = ChoiceCheck(2);
                                                    Console.Clear();
                                                    switch (choice)
                                                    {
                                                        case 1:
                                                            SaveTypeOrCountryOrGenre(g1, dataBaseGenre);
                                                            SaveDevice(d1);
                                                            Console.WriteLine("The change saved successfully");
                                                            Console.WriteLine("Press ENTER to continue");
                                                            Console.ReadLine();
                                                            flag2 = false;
                                                            break;
                                                        case 2:
                                                            flag2 = false;
                                                            continue;
                                                    }
                                                }
                                                break;
                                            case 4:
                                                Console.WriteLine("\t- Admin mode. Delete a type");
                                                Console.WriteLine("Please, pick a type:");
                                                OutputCountryOrGenreOrType(t);
                                                choice = ChoiceCheck(t.Length);
                                                t1 = DeleteCountryOrGenreOrType(t, choice);
                                                d1 = DeleteTypeFromDevice(d, choice);
                                                Console.Clear();
                                                Console.WriteLine("The type's history erased successfully");
                                                Console.WriteLine("Wish to save the change into the the data base?");
                                                flag2 = true;
                                                while (flag2)
                                                {
                                                    Console.WriteLine("1)yes");
                                                    Console.WriteLine("2)no");
                                                    choice = ChoiceCheck(2);
                                                    Console.Clear();
                                                    switch (choice)
                                                    {
                                                        case 1:
                                                            SaveTypeOrCountryOrGenre(t1, dataBaseType);
                                                            SaveDevice(d1);
                                                            Console.WriteLine("The change saved successfully");
                                                            Console.WriteLine("Press ENTER to continue");
                                                            Console.ReadLine();
                                                            flag2 = false;
                                                            break;
                                                        case 2:
                                                            flag2 = false;
                                                            continue;
                                                    }
                                                }
                                                break;
                                            case 5:
                                                flag1 = false;
                                                continue;
                                        }
                                    }
                                    break;
                                case 3:
                                    flag1 = true;
                                    while (flag1)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("\t- Admin mode. Edit option");
                                        Console.WriteLine("Please, pick an object:");
                                        Console.WriteLine("1)Device");
                                        Console.WriteLine("2)Country");
                                        Console.WriteLine("3)Genre");
                                        Console.WriteLine("4)Type");
                                        Console.WriteLine("5)Back");
                                        choice = ChoiceCheck(5);
                                        Console.Clear();
                                        switch (choice)
                                        {
                                            case 1:
                                                Console.WriteLine("\t- Admin mode. Edit a device");
                                                Console.WriteLine("Please, pick a device:");
                                                OutputDevice(d, c, t, g);
                                                choice = ChoiceCheck(d.Length);
                                                Console.Clear();
                                                Console.WriteLine("Write a new data or press ENTER if unnecessary:");
                                                d1 = EditDevice(d,t,c,g,choice);
                                                Console.Clear();
                                                Console.WriteLine("The device changed successfully");
                                                Console.WriteLine("Wish to save the change into the the data base?");
                                                flag2 = true;
                                                while (flag2)
                                                {
                                                    Console.WriteLine("1)yes");
                                                    Console.WriteLine("2)no");
                                                    choice = ChoiceCheck(2);
                                                    Console.Clear();
                                                    switch (choice)
                                                    {
                                                        case 1:
                                                            SaveDevice(d1);
                                                            Console.WriteLine("The change saved successfully");
                                                            Console.WriteLine("Press ENTER to continue");
                                                            Console.ReadLine();
                                                            flag2 = false;
                                                            break;
                                                        case 2:
                                                            flag2 = false;
                                                            continue;
                                                    }
                                                }
                                                break;
                                            case 2:
                                                Console.WriteLine("\t- Admin mode. Edit a country");
                                                Console.WriteLine("Please, pick a country:");
                                                OutputCountryOrGenreOrType(c);
                                                choice = ChoiceCheck(c.Length);
                                                Console.Clear();
                                                Console.WriteLine("Write a new data or press ENTER if unnecessary:");
                                                c1 = EditCountry(c, choice);
                                                Console.Clear();
                                                Console.WriteLine("The country changed successfully");
                                                Console.WriteLine("Wish to save the change into the the data base?");
                                                flag2 = true;
                                                while (flag2)
                                                {
                                                    Console.WriteLine("1)yes");
                                                    Console.WriteLine("2)no");
                                                    choice = ChoiceCheck(2);
                                                    Console.Clear();
                                                    switch (choice)
                                                    {
                                                        case 1:
                                                            SaveTypeOrCountryOrGenre(c1, dataBaseCountry);
                                                            Console.WriteLine("The change saved successfully");
                                                            Console.WriteLine("Press ENTER to continue");
                                                            Console.ReadLine();
                                                            flag2 = false;
                                                            break;
                                                        case 2:
                                                            flag2 = false;
                                                            continue;
                                                    }
                                                }
                                                break;
                                            case 3:
                                                Console.WriteLine("\t- Admin mode. Edit a genre");
                                                Console.WriteLine("Please, pick a genre:");
                                                OutputCountryOrGenreOrType(g);
                                                choice = ChoiceCheck(g.Length);
                                                Console.Clear();
                                                Console.WriteLine("Write a new data or press ENTER if unnecessary:");
                                                g1 = EditGenreOrType(g, choice);
                                                Console.Clear();
                                                Console.WriteLine("The genre changed successfully");
                                                Console.WriteLine("Wish to save the change into the the data base?");
                                                flag2 = true;
                                                while (flag2)
                                                {
                                                    Console.WriteLine("1)yes");
                                                    Console.WriteLine("2)no");
                                                    choice = ChoiceCheck(2);
                                                    Console.Clear();
                                                    switch (choice)
                                                    {
                                                        case 1:
                                                            SaveTypeOrCountryOrGenre(g1, dataBaseGenre);
                                                            Console.WriteLine("The change saved successfully");
                                                            Console.WriteLine("Press ENTER to continue");
                                                            Console.ReadLine();
                                                            flag2 = false;
                                                            break;
                                                        case 2:
                                                            flag2 = false;
                                                            continue;
                                                    }
                                                }
                                                break;
                                            case 4:
                                                Console.WriteLine("\t- Admin mode. Edit a type");
                                                Console.WriteLine("Please, pick a type:");
                                                OutputCountryOrGenreOrType(t);
                                                choice = ChoiceCheck(t.Length);
                                                Console.Clear();
                                                Console.WriteLine("Write a new data or press ENTER if unnecessary:");
                                                t1 = EditGenreOrType(t, choice);
                                                Console.Clear();
                                                Console.WriteLine("The type changed successfully");
                                                Console.WriteLine("Wish to save the change into the the data base?");
                                                flag2 = true;
                                                while (flag2)
                                                {
                                                    Console.WriteLine("1)yes");
                                                    Console.WriteLine("2)no");
                                                    choice = ChoiceCheck(2);
                                                    Console.Clear();
                                                    switch (choice)
                                                    {
                                                        case 1:
                                                            SaveTypeOrCountryOrGenre(t1, dataBaseType);
                                                            Console.WriteLine("The change saved successfully");
                                                            Console.WriteLine("Press ENTER to continue");
                                                            Console.ReadLine();
                                                            flag2 = false;
                                                            break;
                                                        case 2:
                                                            flag2 = false;
                                                            continue;
                                                    }
                                                }
                                                break;
                                            case 5:
                                                flag1 = false;
                                                continue;
                                        }
                                    }
                                    break;
                                case 4:
                                    flag = false;
                                    continue;
                            }
                        }
                        break;
                    case 2:
                        flag = true;
                        while (flag)
                        {
                            Console.Clear();
                            Console.WriteLine("\t- User mode. Please, pick an option from the list:");
                            Console.WriteLine("1)Sort");
                            Console.WriteLine("2)Filtration");
                            Console.WriteLine("3)Back");
                            choice = ChoiceCheck(3);
                            Console.Clear();
                            switch (choice)
                            {
                                case 1:
                                    flag1 = true;
                                    while (flag1)
                                    {
                                        Console.WriteLine("\t- User mode. Sort option");
                                        Console.WriteLine("Please, pick kinds of sort or press ENTER:");
                                        Console.WriteLine("1)By name");
                                        Console.WriteLine("2)By country");
                                        Console.WriteLine("3)By genre");
                                        Console.WriteLine("4)By film amount");
                                        Console.WriteLine("5)By date");
                                        sortChoices = EnterSortChoices();
                                        Console.Clear();
                                        Console.WriteLine("\t- User mode. Sort");
                                        d1 = SortDevice(d, sortChoices);
                                        OutputDevice(d1,c,t,g);
                                        Console.WriteLine("Press ENTER to continue");
                                        Console.ReadLine();
                                        flag1 = false;
                                    }
                                    break;
                                case 2:
                                    flag1 = true;
                                    while (flag1)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("\t- User mode. Filtration option");
                                        Console.WriteLine("Please, pick a kind of filtration:");
                                        Console.WriteLine("1)By type");
                                        Console.WriteLine("2)By name");
                                        Console.WriteLine("3)By genre");
                                        Console.WriteLine("4)By owner");
                                        Console.WriteLine("5)Back");
                                        choice = ChoiceCheck(5);
                                        Console.Clear();
                                        switch (choice)
                                        {
                                            case 1:
                                                Console.WriteLine("\t- User mode. Filtration by type");
                                                Console.WriteLine("Please, pick a type:");
                                                OutputCountryOrGenreOrType(t);
                                                choice = ChoiceCheck(t.Length);
                                                d1 = FiltrationByType(d, choice);
                                                OutputDevice(d1, c, t, g);
                                                Console.WriteLine("Press ENTER to continue");
                                                Console.ReadLine();
                                                break;
                                            case 2:
                                                Console.WriteLine("\t- User mode. Filtration by name");
                                                Console.WriteLine("Please, pick a name:");
                                                FilmList(d, out string[] films);
                                                choice = ChoiceCheck(films.Length);
                                                d1= FiltrationByFilm(d, choice, films);
                                                OutputDevice(d1, c, t, g);
                                                Console.WriteLine("Press ENTER to continue");
                                                Console.ReadLine();
                                                break;
                                            case 3:
                                                Console.WriteLine("\t- User mode. Filtration by genre");
                                                Console.WriteLine("Please, pick a genre:");
                                                OutputCountryOrGenreOrType(g);
                                                choice = ChoiceCheck(g.Length);
                                                d1 = FiltrationByGenre(d, choice);
                                                OutputDevice(d1, c, t, g);
                                                Console.WriteLine("Press ENTER to continue");
                                                Console.ReadLine();
                                                break;
                                            case 4:
                                                Console.WriteLine("\t- User mode. Filtration by owner");
                                                Console.WriteLine("Please, pick an owner:");
                                                OwnerList(d, out string[] owners);
                                                choice = ChoiceCheck(owners.Length);
                                                d1 = FiltrationByOwner(d, choice, owners);
                                                OutputDevice(d1, c, t, g);
                                                Console.WriteLine("Press ENTER to continue");
                                                Console.ReadLine();
                                                break;
                                            case 5:
                                                flag1 = false;
                                                continue;
                                        }
                                    }
                                    break;
                                case 3:
                                    flag = false;
                                    continue;
                            }
                        }
                        break;
                    case 3:
                        flag = true;
                        while (flag)
                        {
                            Console.Clear();
                            Console.WriteLine("\t- Advanced option mode");
                            Console.WriteLine("Please, pick a task to run:");
                            Console.WriteLine("1)Films by genre");
                            Console.WriteLine("2)Film amount by device type & genre");
                            Console.WriteLine("3)Devices by owner");
                            Console.WriteLine("4)Devices with over one film");
                            Console.WriteLine("5)Back");
                            choice = ChoiceCheck(5);
                            Console.Clear();
                            switch (choice)
                            {
                                case 1:
                                    Console.WriteLine("\t- Advanced option mode. Films by genre");
                                    OptionFilmsByGenre(d, c, t, g);
                                    Console.WriteLine("Wish to save the report into the the data base?");
                                    flag1 = true;
                                    while (flag1)
                                    {
                                        Console.WriteLine("1)yes");
                                        Console.WriteLine("2)no");
                                        choice = ChoiceCheck(2);
                                        Console.Clear();
                                        switch (choice)
                                        {
                                            case 1:
                                                SaveReportFilmsByGenre(d, g,c,t, "reportFilmsByGenre.txt");
                                                Console.WriteLine("The report saved successfully");
                                                Console.WriteLine("Press ENTER to continue");
                                                Console.ReadLine();
                                                flag1 = false;
                                                break;
                                            case 2:
                                                flag1 = false;
                                                continue;
                                        }
                                    }
                                    break;
                                case 2:
                                    Console.WriteLine("\t- Advanced option mode. Film number by device type & genre");
                                    OptionFilmNumberByTypeGenre(d,t, g);
                                    Console.WriteLine("Wish to save the report into the the data base?");
                                    flag1 = true;
                                    while (flag1)
                                    {
                                        Console.WriteLine("1)yes");
                                        Console.WriteLine("2)no");
                                        choice = ChoiceCheck(2);
                                        Console.Clear();
                                        switch (choice)
                                        {
                                            case 1:
                                                SaveReportFilmNumberByTypeGenre(d, g, t, "reportFilmNumberByTypeGenre.txt");
                                                Console.WriteLine("The report saved successfully");
                                                Console.WriteLine("Press ENTER to continue");
                                                Console.ReadLine();
                                                flag1 = false;
                                                break;
                                            case 2:
                                                flag1 = false;
                                                continue;
                                        }
                                    }
                                    break;
                                case 3:
                                    Console.WriteLine("\t- Advanced option mode. Devices by owner");
                                    OptionFilmsByOwner(d, c, t);
                                    Console.WriteLine("Wish to save the report into the the data base?");
                                    flag1 = true;
                                    while (flag1)
                                    {
                                        Console.WriteLine("1)yes");
                                        Console.WriteLine("2)no");
                                        choice = ChoiceCheck(2);
                                        Console.Clear();
                                        switch (choice)
                                        {
                                            case 1:
                                                SaveReportFilmsByOwner(d,c,t, "reportFilmsByOwner.txt");
                                                Console.WriteLine("The report saved successfully");
                                                Console.WriteLine("Press ENTER to continue");
                                                Console.ReadLine();
                                                flag1 = false;
                                                break;
                                            case 2:
                                                flag1 = false;
                                                continue;
                                        }
                                    }
                                    break;
                                case 4:
                                    Console.WriteLine("\t- Advanced option mode. Devices with over one film");
                                    OptionDeviceOverOneFilm(d, c, t);
                                    Console.WriteLine("Wish to save the report into the the data base?");
                                    flag1 = true;
                                    while (flag1)
                                    {
                                        Console.WriteLine("1)yes");
                                        Console.WriteLine("2)no");
                                        choice = ChoiceCheck(2);
                                        Console.Clear();
                                        switch (choice)
                                        {
                                            case 1:
                                                SaveReportDeviceOverOneFilm(d, c, t, "reportDeviceOverOneFilm.txt");
                                                Console.WriteLine("The report saved successfully");
                                                Console.WriteLine("Press ENTER to continue");
                                                Console.ReadLine();
                                                flag1 = false;
                                                break;
                                            case 2:
                                                flag1 = false;
                                                continue;
                                        }
                                    }
                                    break;
                                case 5:
                                    flag = false;
                                    continue;
                            }
                        }
                        break;
                    case 4:
                        Console.WriteLine("Thank you so much for attention! :)");
                        Console.ReadLine();
                        return;
                }
            }
        }
        else
        {
            Console.WriteLine("Sorry, data base wasn't found. Please, add a source to continue");
            Console.ReadLine();
        }
    }
}