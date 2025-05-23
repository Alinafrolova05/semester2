using LZW;
using System.Collections;
using System.Collections.Generic;

Tree treeBor = new ("text.txt");
treeBor.Compress();
treeBor.Decompress();
