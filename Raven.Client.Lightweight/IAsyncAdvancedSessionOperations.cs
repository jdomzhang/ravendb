//-----------------------------------------------------------------------
// <copyright file="IAsyncAdvancedSessionOperations.cs" company="Hibernating Rhinos LTD">
//     Copyright (c) Hibernating Rhinos LTD. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
#if !NET_3_5

using Raven.Client.Client.Async;

namespace Raven.Client
{
    /// <summary>
    /// Advanced async session operations
    /// </summary>
    public interface IAsyncAdvancedSessionOperations : IAdvancedDocumentSessionOperations
    {
        /// <summary>
        /// Gets the async database commands.
        /// </summary>
        /// <value>The async database commands.</value>
        IAsyncDatabaseCommands AsyncDatabaseCommands { get; }
    }
}
#endif