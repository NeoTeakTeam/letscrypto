using core;

// Test

Console.WriteLine("Hello, World!");

var coreInstance = new Core();

string key = coreInstance.generateKey();
int offset = coreInstance.randomOffset();

Console.WriteLine(coreInstance.encrypt("This is a text", key, offset));
Console.WriteLine(coreInstance.encrypt("This is a text", key, offset));
