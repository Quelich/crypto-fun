# crypto-fun
Some of the cryptography concepts implemented in C#

## Components
### `Qcrypto`
Takes two parameters: `Input` and `SaltSize`. `SaltSize` is the same for all encryption functions.

## Input
`string input = "Emre";`  
`EncryptSha256()` hashes the input with SHA256 encryption.  
`EncryptBlake2B(256)` hashes the input with Blake2 encryption. You can specify `hashSize` parameter.  
`EncryptArgon2(128)` hashes the input with Argon2 encryption. You can specify `hashSize` parameter.  
`EncryptHMACSHA256("1")` hashes the input and key with HMACSHA256 encryption. You must specify a `key` parameter.  

## Output
- SHA256  
`f28885e3996cc30a63812091276018cfb94936c1c836490ef4c8180f1dab2a1b`  
- Blake2B  
`d7200c1633b5c468860a4781a5b22de65a2975c2f269ac3f4c18ac79f98c8e68`  
- Argon2  
`1dab2ffc6cab658c7e347b338549f1d6a58696701439d08f30f5871c9ac43adbddb1446037af8ff6904d6e158075a3e0447c01cc644d03950d492608fe51a4df` 
- HMACSHA256  
`key=1, input="Emre"`  
`bb124d24c604b14fac67b331e67e5a81f5531e7f8c55750d8602a338d2ba21df`  
`key=2, input="Emre`  
`b509d0ad6bf1a1005a980b1576df1f5981ee0383bcdc2c9a38deac737d9a9c3b`  
