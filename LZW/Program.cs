using LZW;
using System.Collections;
using System.Collections.Generic;

Tree tree = new ();
tree.Compress("text.txt");
tree.Decompress("text.zipped");
