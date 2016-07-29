// ------------------------------------------------------------------------------------------------------------------------
// <copyright file="BoxSetsHandler.cs" company="">
//   
// </copyright>
// <summary>
//   The box sets handler.
// </summary>
// ------------------------------------------------------------------------------------------------------------------------

namespace AutoBoxSets.Api
{

    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using JetBrains.Annotations;

    using MediaBrowser.Controller.Net;

    using ServiceStack;


    /// <summary>The box sets handler.</summary>
    internal class BoxSetsHandler : IRestfulService, IService
    {
        /// <summary>The post.</summary>
        /// <param name="request">The request.</param>
        /// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
        [UsedImplicitly]
        public void Post(RefreshRequest request)
        {
            Task.WhenAll(Plugin.Instance.CreateAllBoxSetsAsync(new Progress<double>(), CancellationToken.None));
        }
    }

}
