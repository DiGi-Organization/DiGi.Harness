using DiGi.Harness.Classes;
using System.Threading;
using System.Threading.Tasks;

namespace DiGi.Harness.Interfaces
{
    /// <summary>
    /// A tool the model can call during a turn.
    /// </summary>
    public interface ITool : IHarnessObject
    {
        /// <summary>
        /// Gets the definition sent to the model: the name, description and JSON input schema.
        /// </summary>
        ToolDefinition ToolDefinition { get; }

        /// <summary>
        /// Runs the tool for one call made by the model.
        /// <para>A failure the model should see is returned as a result with <see cref="ToolResultContent.IsError"/> set, never thrown; only a requested cancellation is rethrown.</para>
        /// </summary>
        /// <param name="toolUseContent">The call made by the model, including its input.</param>
        /// <param name="cancellationToken">The token that cancels the call.</param>
        /// <returns>The result returned to the model.</returns>
        Task<ToolResultContent> InvokeAsync(ToolUseContent toolUseContent, CancellationToken cancellationToken = default);
    }
}
