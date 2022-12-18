﻿using System.Diagnostics;

namespace SelectionProcessValidation;
public class SelectionProcessValidation
{
    /// <summary>
    /// This function is to add two numbers
    /// </summary>
    /// <param name="selectedPeople"> Selected people </param>
    /// <param name="name"> The name of the validated person</param>
    /// <returns>The result of name validation</returns>
    /// <exception cref="ArgumentException">If name is null or an empty string</exception>
    public bool ValidateName(string selectedPeople, string name) 
    {
        if (string.IsNullOrEmpty(selectedPeople) || string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("O campo nome está vazio");
        }
        return selectedPeople.Contains(name);
    }
}
