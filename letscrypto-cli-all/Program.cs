using core;
using System.CommandLine;

var coreInstance = new Core();

void generateKey(int count, string save)
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

void encrypt(string text, string file, string key, string offset, string save)
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

void decrypt(string text, string file, string key, int offset, string save)
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

var generateKeyCountOption = new Option<int>(
    aliases: new string[] { "--count", "-c" },
    description: "The number of keys to generate a key",
    getDefaultValue: () => 20
);
var generateKeySaveOption = new Option<string>(
    "--save",
    description: "Save the key to a file",
    getDefaultValue: () => "__Letscrypto_console__"
);
var generateKeyCommand = new Command("generateKey", description: "generate a key")
{
    generateKeyCountOption,
    generateKeySaveOption,
};

var encryptOutputSaveOption = new Option<string>(
    "--save",
    description: "Save the encrypted text to a file",
    getDefaultValue: () => "__Letscrypto_console__"
);
var encryptKeyFileOption = new Option<string>(
    aliases: new string[] { "--key", "-k" },
    description: "The key to encrypt the text",
    getDefaultValue: () => "__Letscrypto_default__"
);
var encryptOffsetOption = new Option<string>(
    aliases: new string[] { "--offset", "-o" },
    description: "The offset to encrypt the text",
    getDefaultValue: () => "__Letscrypto_random__"
);
var encryptTextOption = new Option<string>(
        aliases: new string[] { "--text", "-t" },
        description: "The text to encrypt",
        getDefaultValue: () => "__Letscrypto_null__"
    );
var encryptFileOption = new Option<string>(
    aliases: new string[] { "--file", "-f" },
    description: "The file to encrypt",
    getDefaultValue: () => "__Letscrypto_null__"
);
var encryptCommand = new Command("encrypt", description: "encrypt a text or a file")
{
    encryptTextOption,
    encryptFileOption,
    encryptKeyFileOption,
    encryptOffsetOption,
    encryptOutputSaveOption,
};

var decryptOutputSaveOption = new Option<string>(
    "--save",
    description: "Save the encrypted text to a file",
    getDefaultValue: () => "__Letscrypto_console__"
);
var decryptKeyFileOption = new Option<string>(
    aliases: new string[] { "--key", "-k" },
    description: "The key to encrypt the text"
);
var decryptOffsetOption = new Option<int>(
    aliases: new string[] { "--offset", "-o" },
    description: "The offset to encrypt the text"
);
var decryptTextOption = new Option<string>(
        aliases: new string[] { "--text", "-t" },
        description: "The text to decrypt",
        getDefaultValue: () => "__Letscrypto_null__"
    );
var decryptFileOption = new Option<string>(
    aliases: new string[] { "--file", "-f" },
    description: "The file to decrypt",
    getDefaultValue: () => "__Letscrypto_null__"
);
var decryptCommand = new Command("decrypt", description: "decrypt a text or a file")
{
    decryptTextOption,
    decryptFileOption,
    decryptKeyFileOption,
    decryptOffsetOption,
    decryptOutputSaveOption,
};

var rootCommand = new RootCommand("Let's encrypt together!");
rootCommand.AddCommand(generateKeyCommand);
rootCommand.AddCommand(encryptCommand);
rootCommand.AddCommand(decryptCommand);

generateKeyCommand.SetHandler(generateKey, generateKeyCountOption, generateKeySaveOption);

encryptCommand.SetHandler(
    encrypt,
    encryptTextOption,
    encryptFileOption,
    encryptKeyFileOption,
    encryptOffsetOption,
    encryptOutputSaveOption
);

decryptCommand.SetHandler(
    decrypt,
    decryptTextOption,
    decryptFileOption,
    decryptKeyFileOption,
    decryptOffsetOption,
    decryptOutputSaveOption
);

return await rootCommand.InvokeAsync(args);
