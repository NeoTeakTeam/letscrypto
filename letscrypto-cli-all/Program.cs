using core;
using System.CommandLine;
using tools;

var coreInstance = new Core();
Tools tool = new();

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

generateKeyCommand.SetHandler(tool.generateKey, generateKeyCountOption, generateKeySaveOption);

encryptCommand.SetHandler(
    tool.encrypt,
    encryptTextOption,
    encryptFileOption,
    encryptKeyFileOption,
    encryptOffsetOption,
    encryptOutputSaveOption
);

decryptCommand.SetHandler(
    tool.decrypt,
    decryptTextOption,
    decryptFileOption,
    decryptKeyFileOption,
    decryptOffsetOption,
    decryptOutputSaveOption
);

return await rootCommand.InvokeAsync(args);
