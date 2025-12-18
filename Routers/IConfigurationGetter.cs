// <copyright file="IConfigurationGetter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Routers;

/// <summary>
/// Defines methods for creating router network configurations.
/// </summary>
internal interface IConfigurationGetter
{
    /// <summary>
    /// Generates router network configuration.
    /// </summary>
    /// <returns> Configuretion graph. </returns>
    public Dictionary<int, Dictionary<int, int>>? GetConfiguration();
}
