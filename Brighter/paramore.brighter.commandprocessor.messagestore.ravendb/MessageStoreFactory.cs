// ***********************************************************************
// Assembly         : paramore.brighter.commandprocessor.messagestore.ravendb
// Author           : ian
// Created          : 07-01-2014
//
// Last Modified By : ian
// Last Modified On : 07-10-2014
// ***********************************************************************
// <copyright file="MessageStoreFactory.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
#region Licence
/* The MIT License (MIT)
Copyright � 2014 Ian Cooper <ian_hammond_cooper@yahoo.co.uk>

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the �Software�), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED �AS IS�, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE. */
#endregion

using System;
using Raven.Client;
using Raven.Client.Document;

namespace paramore.brighter.commandprocessor.messagestore.ravendb
{
    /// <summary>
    /// Class MessageStoreFactory.
    /// The MessageStoreFactory creates a RavenDB message store. It is a singleton, and will always return the same message store after the first call, within a given process.
    /// This is by design, there is no support for multiple message stores, nor envisaged need.
    /// </summary>
    public class MessageStoreFactory
    {

        private static readonly Lazy<DocumentStore> DOCUMENT_STORE = new Lazy<DocumentStore>(()=>
        {
            var ds = new DocumentStore
                {
                    ConnectionStringName = "MessageStore"
                };

            ds.Initialize();

            return ds;
        });

        /// <summary>
        /// Gets the document store.
        /// </summary>
        /// <value>The document store.</value>
        public static IDocumentStore DocumentStore
        {
            get { return DOCUMENT_STORE.Value; }
        }
    }
}