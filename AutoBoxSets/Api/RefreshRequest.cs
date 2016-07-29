// ------------------------------------------------------------------------------------------------------------------------
// <copyright file="RefreshRequest.cs" company="">
//   
// </copyright>
// <summary>
//   The refresh request.
// </summary>
// ------------------------------------------------------------------------------------------------------------------------

namespace AutoBoxSets.Api
{

    using JetBrains.Annotations;

    using ServiceStack;


    /// <summary>The refresh request.</summary>
    [Route("/AutoBoxSets/Refresh", "POST"), Api(Description = "Private to AutoBoxSets"), Restrict(VisibilityTo = RequestAttributes.None), 
     UsedImplicitly]
    internal class RefreshRequest
    {
    }

}
