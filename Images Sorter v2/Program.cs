namespace Images_Sorter_v2
{
    class Program
    {
        static void Sorting(string source)
        {
            try
            {
                var files = Directory.GetFiles(source);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Found "+ files.Length + "files.\n");

                foreach (var file in files)
                {
                    string fileName = Path.GetFileName(file);
                    FileInfo fileInfo = new FileInfo(file);
                    float fileSize = fileInfo.Length / 1048576;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(file + ": " + fileSize);

                    string dateTaken = fileInfo.LastWriteTime.ToShortDateString();
                    string yearTaken = dateTaken.Split('.')[2];
                    string monthTaken = dateTaken.Split('.')[1];
                    switch (monthTaken)
                    {
                        case "01":
                            monthTaken = "1. Styczeń";
                            break;

                        case "02":
                            monthTaken = "2. Luty";
                            break;

                        case "03":
                            monthTaken = "3. Marzec";
                            break;

                        case "04":
                            monthTaken = "4. Kwiecień";
                            break;

                        case "05":
                            monthTaken = "5. Maj";
                            break;

                        case "06":
                            monthTaken = "6. Czerwiec";
                            break;

                        case "07":
                            monthTaken = "7. Lipiec";
                            break;

                        case "08":
                            monthTaken = "8. Sierpień";
                            break;

                        case "09":
                            monthTaken = "9. Wrzesień";
                            break;

                        case "10":
                            monthTaken = "10. Październik";
                            break;

                        case "11":
                            monthTaken = "11. Listopad";
                            break;

                        case "12":
                            monthTaken = "12. Grudzień";
                            break;

                        default:
                            monthTaken = "NaN";
                            break;
                    }

                    if (monthTaken != "NaN")
                    {
                        string dest = source + @"\" + yearTaken + @"\" + monthTaken + @"\" + dateTaken;
                        Directory.CreateDirectory(dest);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Moved to: " + dest);
                        string pathToFile = dest + @"\" + fileName;
                        fileInfo.MoveTo(pathToFile);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: Month doesn't match.");
                        Environment.Exit(1);
                    }
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Succesfully moved " + files.Length + " files.\nPress enter to exit.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.ToString());
            }
        }
        static void Main(string[] args)
        {
            string CFG_Dir = @"C:\Users\" + Environment.UserName + @"\Documents\ImagesSorter.cfg";
            if (!Directory.Exists(CFG_Dir))
            {
                Console.WriteLine("No .cfg file was found. Creating one.\n   Write your source directory for photos:\n");
                string photoDIR = Console.ReadLine();
                File.WriteAllText(CFG_Dir, photoDIR + "\n");
            }
            Sorting(Convert.ToBase64String(File.ReadAllBytes(CFG_Dir)));
        }
    }
}