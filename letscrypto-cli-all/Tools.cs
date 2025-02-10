using core;

namespace tools
{
    class Tools
    {
        private Core coreInstance = new();
        public void generateKey(int count, string save)
        {
            var key = coreInstance.generateKey(count);
            var formatKey = coreInstance.formatKey(key);

            if (save == "__Letscrypto_console__")
            {
                Console.WriteLine(formatKey);
            }
            else
            {
                File.WriteAllText(save, formatKey);
            }
        }

        public void encrypt(string text, string file, string key, string offset, string save)
        {
            var context = "";

            if (text != "__Letscrypto_null__")
            {
                if (file == "__Letscrypto_null__")
                {
                    context = text;
                }
                else
                {
                    Console.WriteLine("Please provide a text or a file to encrypt");
                    return;
                }
            }
            else
            {
                if (file != "__Letscrypto_null__")
                {
                    if (!File.Exists(file))
                    {
                        Console.WriteLine("The file does not exist");
                        return;
                    }
                    context = File.ReadAllText(file);
                }
                else
                {
                    Console.WriteLine("Please provide a text or a file to encrypt");
                    return;
                }
            }

            var realOffset = 0;
            if (offset == "__Letscrypto_random__")
            {
                realOffset = coreInstance.randomOffset();
                Console.WriteLine($"Use a random offset: {realOffset}");
            }
            else
            {
                if (!int.TryParse(offset, out realOffset))
                {
                    realOffset = coreInstance.randomOffset();
                }
            }

            var realKey = "";
            if (key == "__Letscrypto_default__")
            {
                realKey = coreInstance.generateKey();
                Console.WriteLine("Use a random key:");
                Console.WriteLine(coreInstance.formatKey(realKey));
            }
            else
            {
                if (!File.Exists(key))
                {
                    Console.WriteLine("The key file does not exist");
                    return;
                }
                var keyLines = File.ReadAllLines(key);

                // 检测头部和尾部
                if (keyLines.First() != "------------------- Key --------------------" ||
                    keyLines.Last() != "------------------- End --------------------")
                {
                    Console.WriteLine("The key file is invalid");
                    return;
                }

                var realKeyLists = keyLines.Skip(1).Take(keyLines.Count() - 2).ToList();
                if (realKeyLists == null || !realKeyLists.Any())
                {
                    Console.WriteLine("The key file is invalid(no data)");
                    return;
                }
                realKey = string.Join("", realKeyLists).Replace("\n", "");
                Console.WriteLine($"Use a custom key file: {key}");
            }

            var encryptedText = coreInstance.encrypt(context, realKey, realOffset);
            if (save == "__Letscrypto_console__")
            {
                Console.WriteLine($"Encrypted text: {encryptedText}");
            }
            else
            {
                File.WriteAllText(save, encryptedText);
            }
        }

        public void decrypt(string text, string file, string key, int offset, string save)
        {
            var context = "";

            if (text != "__Letscrypto_null__")
            {
                if (file == "__Letscrypto_null__")
                {
                    context = text;
                }
                else
                {
                    Console.WriteLine("Please provide a text or a file to encrypt");
                    return;
                }
            }
            else
            {
                if (file != "__Letscrypto_null__")
                {
                    if (!File.Exists(file))
                    {
                        Console.WriteLine("The file does not exist");
                        return;
                    }
                    context = File.ReadAllText(file);
                }
                else
                {
                    Console.WriteLine("Please provide a text or a file to encrypt");
                    return;
                }
            }

            var realKey = "";

            if (!File.Exists(key))
            {
                Console.WriteLine("The key file does not exist");
                return;
            }
            var keyLines = File.ReadAllLines(key);

            // 检测头部和尾部
            if (keyLines.First() != "------------------- Key --------------------" ||
                keyLines.Last() != "------------------- End --------------------")
            {
                Console.WriteLine("The key file is invalid");
                return;
            }

            var realKeyLists = keyLines.Skip(1).Take(keyLines.Count() - 2).ToList();
            if (realKeyLists == null || !realKeyLists.Any())
            {
                Console.WriteLine("The key file is invalid(no data)");
                return;
            }
            realKey = string.Join("", realKeyLists).Replace("\n", "");
            Console.WriteLine($"Use a custom key file: {key}");

            var encryptedText = coreInstance.decrypt(context, realKey, offset);
            if (save == "__Letscrypto_console__")
            {
                Console.WriteLine($"Decrypted text: {encryptedText}");
            }
            else
            {
                File.WriteAllText(save, encryptedText);
            }
        }
    }
}
