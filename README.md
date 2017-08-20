You need .NET Core 2.0 installed in order for this thing to run.
You may also want to install Node.js if you want to build front-end all by yourself, but I have committed a prebuilt bundles so 
you don't really need to.

I suggest using Visual Studio Code or any other lightweight editor (Atom, Sublime or Vim if you are a pro) for navigation as I didn't
bother adding .sln file so you may have issues opening it with Visual Studio or Rider unless you add it yourself which should not 
be difficult thing to do.

The code could use some refactoring but given the idea is to expose an end-to-end Gql + .NET solution I couldn't care less. 
Also, the attached Sqlite db schema consists of 13 entities but I only used 3 in this example, feel free to extend it in order to 
catch up.
