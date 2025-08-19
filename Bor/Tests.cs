// <copyright file="Tests.cs" company="Alina">
// Copyright (c) Alina. All rights reserved.
// </copyright>

namespace Bor;

/// <summary>
/// Tests Bor.
/// </summary>
public class Tests
{
    private Bor bor = new Bor();

    /// <summary>
    /// Tests Bor.
    /// </summary>
    /// <returns> True or false. </returns>
    public bool RunTests()
    {
        bool allTestsPassed = true;

        allTestsPassed &= this.TestAddSingleWord();
        allTestsPassed &= this.TestAddDuplicateWord();
        allTestsPassed &= this.TestAddMultipleWords();
        allTestsPassed &= this.TestAddEmptyString();
        allTestsPassed &= this.TestAddWhitespaceString();
        allTestsPassed &= this.TestRemoveWord();
        allTestsPassed &= this.TestRemoveNonExistentWord();
        allTestsPassed &= this.TestHowManyStartsWithPrefix();

        return allTestsPassed;
    }

    private bool TestAddSingleWord()
    {
        bool result = this.bor.Add("he");
        return result && this.bor.Size == 1;
    }

    private bool TestAddDuplicateWord()
    {
        this.bor.Add("he");
        bool result = this.bor.Add("he");
        return !result && this.bor.Size == 1;
    }

    private bool TestAddMultipleWords()
    {
        this.bor.Add("he");
        this.bor.Add("hers");
        this.bor.Add("hello");
        return this.bor.Size == 3;
    }

    private bool TestAddEmptyString()
    {
        bool result = this.bor.Add("");
        return result && this.bor.Size == 1;
    }

    private bool TestAddWhitespaceString()
    {
        bool result = this.bor.Add("  ");
        return result && this.bor.Size == 1;
    }

    private bool TestRemoveWord()
    {
        this.bor.Add("he");
        this.bor.Add("hers");
        bool result = this.bor.RemoveWord("he");
        return result && this.bor.Size == 1; 
    }

    private bool TestRemoveNonExistentWord()
    {
        this.bor.Add("he");
        bool result = this.bor.RemoveWord("hello");
        return !result && this.bor.Size == 1;
    }

    private bool TestHowManyStartsWithPrefix()
    {
        this.bor.Add("he");
        this.bor.Add("hello");
        this.bor.Add("hers");

        return this.bor.HowManyStartsWithPrefix("he") == 3 &&
               this.bor.HowManyStartsWithPrefix("hel") == 2 &&
               this.bor.HowManyStartsWithPrefix("hi") == 0;
    }
}
