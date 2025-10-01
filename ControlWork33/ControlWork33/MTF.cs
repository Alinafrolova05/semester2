// <copyright file="MTF.cs" company="Alinafrolova05">
// Copyright (c) Alinafrolova05. All rights reserved.
// </copyright>

namespace ControlWork33;

/// <summary>
/// Algorithm MTF.
/// </summary>
public class MTF
{
    private string str;
    private char[] alphabet;

    /// <summary>
    /// Initializes a new instance of the <see cref="MTF"/> class.
    /// </summary>
    /// <param name="string1"> Parametor. </param>
    public MTF(string string1)
    {
        this.str = string1;
        this.alphabet = new char[string1.Length];

        int index = 0;
        foreach (var element in string1)
        {
            if (!this.alphabet.Contains(element))
            {
                this.alphabet[index] = element;
                index++;
            }
        }
    }

    /// <summary>
    /// ToConvertAlfavit.
    /// </summary>
    /// <param name="element"> p. </param>
    public void ConvertAlfavit(char element)
    {
        for (int i = 0; i < this.alphabet.Length; i++)
        {
            if (this.alphabet[i] == element)
            {
                this.AddElementToAlphabet(i, element);
                return;
            }
        }
    }

    /// <summary>
    /// ToRemoveElementInAlfavit.
    /// </summary>
    /// <param name="index"> p. </param>
    /// <param name="element"> p .</param>
    public void AddElementToAlphabet(int index, char element)
    {
        for (int i = 1; i < index; i++)
        {
            this.alphabet[i] = this.alphabet[i - 1];
        }

        this.alphabet[0] = element;
    }

    /// <summary>
    /// ToConvertString.
    /// </summary>
    public void ConvertString()
    {
        int[] convertedString = new int[this.str.Length];

        for (int i = 0; i < this.str.Length; i++)
        {
            for (int j = 0; j < this.alphabet.Length; ++j)
            {
                if (this.str[i] == this.alphabet[j])
                {
                    convertedString[i] = j;
                    this.ConvertAlfavit(this.str[i]);
                }
            }
        }
    }
}
