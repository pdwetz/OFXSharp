# Background
An OFX reader for financial data exports (bank account, credit card, etc). Currently targeting netstandard2.0, but other than that (and that it's targeting a more recent SGML parser) it's the same as the original fork. No public nuget, but can be published locally and referenced by projects.

# Basic Usage

```
var parser = new OFXDocumentParser();
var ofxDocument = parser.Import(new FileStream(@"c:\ofxdoc.ofx", FileMode.Open));
```
