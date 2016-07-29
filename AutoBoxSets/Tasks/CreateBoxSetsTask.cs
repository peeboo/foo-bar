// ------------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateBoxSetsTask.cs" company="">
//   
// </copyright>
// <summary>
//   The create box sets task.
// </summary>
// ------------------------------------------------------------------------------------------------------------------------

namespace AutoBoxSets.Tasks
{

    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using JetBrains.Annotations;

    using MediaBrowser.Controller.Library;


    /// <summary>The create box sets task.</summary>
    public class CreateBoxSetsTask : ILibraryPostScanTask
    {
        /// <summary>The run.</summary>
        /// <param name="progress">The progress.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        /// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
        [NotNull]
        public Task Run(IProgress<double> progress, CancellationToken cancellationToken)
        {
            return Plugin.Instance.CreateAllBoxSetsAsync(progress, cancellationToken);
        }
    }

}
