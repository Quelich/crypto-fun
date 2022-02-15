# crypto-fun
Some of cryptography concepts implemented in C#

## Components
### `Qcrypto`
Takes two paramaters: `Input` and `SaltSize`. `SaltSize` is same for all encryption functions.

## Input
`string input = "Emre";`  
`EncryptSha256()` encryptes the input with SHA256 encryption.  
`EncryptBlake2B(256)` encryptes the input with Blake2 encryption. You can also specify `hashSize` paramater.  
`EncryptArgon2(128)` encryptes the input with Argon2 encryption. You can also specify `hashSize` paramater.  

## Output
SHA256  
`f28885e3996cc30a63812091276018cfb94936c1c836490ef4c8180f1dab2a1b`  
Blake2B  
`d7200c1633b5c468860a4781a5b22de65a2975c2f269ac3f4c18ac79f98c8e68`  
Blake2B  
`1dab2ffc6cab658c7e347b338549f1d6a58696701439d08f30f5871c9ac43adbddb1446037af8ff6904d6e158075a3e0447c01cc644d03950d492608fe51a4df`   
