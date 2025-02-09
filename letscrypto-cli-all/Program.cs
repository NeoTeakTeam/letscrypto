using System.CommandLine;
using core;

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
        System.IO.File.WriteAllText(save, formatKey);
    }
}

void encryptText(string text, string key, string offset, string save)
{
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
        realKey = System.IO.File.ReadAllText(key);
        realKey = realKey.Substring(44, realKey.Length - 44 - 44).Replace("\n", "");
        Console.WriteLine($"Use a custom key file: {key}");
    }

    var encryptedText = coreInstance.encrypt(text, key, realOffset);
    if (save == "__Letscrypto_console__")
    {
        Console.WriteLine($"Encrypted text: {encryptedText}");
    }
    else
    {
        System.IO.File.WriteAllText(save, encryptedText);
    }
}

void encryptFile(string file, string key, string offset, string save)
{
    var text = System.IO.File.ReadAllText(file);
    encryptText(text, key, offset, save);
}

void decryptText(string text, string key, int offset, string save)
{
    var realKey = "";

    realKey = System.IO.File.ReadAllText(key);
    realKey = realKey.Substring(44, realKey.Length - 44 - 44).Replace("\n", "");
    Console.WriteLine($"Use a custom key file: {key}");

    var encryptedText = coreInstance.decrypt(text, key, offset);
    if (save == "__Letscrypto_console__")
    {
        Console.WriteLine($"Decrypted text: {encryptedText}");
    }
    else
    {
        System.IO.File.WriteAllText(save, encryptedText);
    }
}

void decryptFile(string file, string key, int offset, string save)
{
    var text = System.IO.File.ReadAllText(file);
    decryptText(text, key, offset, save);
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
var encryptTextArgument = new Argument<string>("text", description: "The text to encrypt");
var encryptTextCommand = new Command("encryptText", description: "encrypt a text")
{
    encryptTextArgument,
    encryptKeyFileOption,
    encryptOffsetOption,
    encryptOutputSaveOption,
};

var encryptFileArgument = new Argument<string>("file", description: "The file to encrypt");
var encryptFileCommand = new Command("encryptFile", description: "encrypt a file")
{
    encryptFileArgument,
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
    description: "The key to encrypt the text",
    getDefaultValue: () => "__Letscrypto_default__"
);
var decryptOffsetOption = new Option<int>(
    aliases: new string[] { "--offset", "-o" },
    description: "The offset to encrypt the text"
);
var decryptTextArgument = new Argument<string>("text", description: "The text to decrypt");
var decryptTextCommand = new Command("decryptText", description: "decrypt a text")
{
    decryptTextArgument,
    decryptKeyFileOption,
    decryptOffsetOption,
    decryptOutputSaveOption,
};

var decryptFileArgument = new Argument<string>("file", description: "The file to decrypt");
var decryptFileCommand = new Command("decryptFile", description: "decrypt a file")
{
    decryptFileArgument,
    decryptKeyFileOption,
    decryptOffsetOption,
    decryptOutputSaveOption,
};

var rootCommand = new RootCommand("Let's encrypt together!");
rootCommand.AddCommand(generateKeyCommand);
rootCommand.AddCommand(encryptTextCommand);
rootCommand.AddCommand(encryptFileCommand);
rootCommand.AddCommand(decryptTextCommand);
rootCommand.AddCommand(decryptFileCommand);

generateKeyCommand.SetHandler(generateKey, generateKeyCountOption, generateKeySaveOption);

encryptTextCommand.SetHandler(
    encryptText,
    encryptTextArgument,
    encryptKeyFileOption,
    encryptOffsetOption,
    encryptOutputSaveOption
);

encryptFileCommand.SetHandler(
    encryptFile,
    encryptFileArgument,
    encryptKeyFileOption,
    encryptOffsetOption,
    encryptOutputSaveOption
);

decryptTextCommand.SetHandler(
    decryptText,
    decryptTextArgument,
    decryptKeyFileOption,
    decryptOffsetOption,
    decryptOutputSaveOption
);

decryptFileCommand.SetHandler(
    decryptFile,
    decryptFileArgument,
    decryptKeyFileOption,
    decryptOffsetOption,
    decryptOutputSaveOption
);

return await rootCommand.InvokeAsync(args);
