#### [DiGi\.Harness](DiGi.Harness.Overview.md 'DiGi\.Harness\.Overview')

## DiGi\.Harness\.Classes Namespace
### Classes

<a name='DiGi.Harness.Classes.CallEndpointTool'></a>

## CallEndpointTool Class

The `call_endpoint` tool: calls one operation of a WebAPI described by an OpenAPI document, with the signed\-in user's bearer token\.

Guarded so the model cannot reach anything else: the path must match an operation of the document under `pathPrefix` ([PathTemplate\(this JsonObject, string, string\)](DiGi.Harness.md#DiGi.Harness.Query.PathTemplate(thisSystem.Text.Json.Nodes.JsonObject,string,string) 'DiGi\.Harness\.Query\.PathTemplate\(this System\.Text\.Json\.Nodes\.JsonObject, string, string\)') rejects absolute, protocol-relative and `..` paths, queries and fragments), the request always goes to the fixed base URI, GET is always allowed, and POST only for path templates on the allowlist. Query values are URL-encoded. A binary response is described, not returned.

```csharp
public class CallEndpointTool : DiGi.Harness.Interfaces.ITool, DiGi.Harness.Interfaces.IHarnessObject, DiGi.Core.Interfaces.IObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CallEndpointTool

Implements [ITool](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.ITool 'DiGi\.Harness\.Interfaces\.ITool'), [IHarnessObject](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IHarnessObject 'DiGi\.Harness\.Interfaces\.IHarnessObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject')
### Constructors

<a name='DiGi.Harness.Classes.CallEndpointTool.CallEndpointTool(System.Uri,string,System.Text.Json.Nodes.JsonObject,System.Collections.Generic.IEnumerable_string_,string,System.Net.Http.HttpClient)'></a>

## CallEndpointTool\(Uri, string, JsonObject, IEnumerable\<string\>, string, HttpClient\) Constructor

Initializes a new instance of the [CallEndpointTool](DiGi.Harness.Classes.md#DiGi.Harness.Classes.CallEndpointTool 'DiGi\.Harness\.Classes\.CallEndpointTool') class\.

```csharp
public CallEndpointTool(System.Uri baseUri, string? pathPrefix, System.Text.Json.Nodes.JsonObject? swagger, System.Collections.Generic.IEnumerable<string>? postPathTemplates, string? bearerToken, System.Net.Http.HttpClient httpClient);
```
#### Parameters

<a name='DiGi.Harness.Classes.CallEndpointTool.CallEndpointTool(System.Uri,string,System.Text.Json.Nodes.JsonObject,System.Collections.Generic.IEnumerable_string_,string,System.Net.Http.HttpClient).baseUri'></a>

`baseUri` [System\.Uri](https://learn.microsoft.com/en-us/dotnet/api/system.uri 'System\.Uri')

The base URI every request goes to, such as `https://api.digiproject.uk`\.

<a name='DiGi.Harness.Classes.CallEndpointTool.CallEndpointTool(System.Uri,string,System.Text.Json.Nodes.JsonObject,System.Collections.Generic.IEnumerable_string_,string,System.Net.Http.HttpClient).pathPrefix'></a>

`pathPrefix` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path prefix the model may call, such as `/gis/`; null allows every path of the document\.

<a name='DiGi.Harness.Classes.CallEndpointTool.CallEndpointTool(System.Uri,string,System.Text.Json.Nodes.JsonObject,System.Collections.Generic.IEnumerable_string_,string,System.Net.Http.HttpClient).swagger'></a>

`swagger` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The OpenAPI document listing the callable operations\.

<a name='DiGi.Harness.Classes.CallEndpointTool.CallEndpointTool(System.Uri,string,System.Text.Json.Nodes.JsonObject,System.Collections.Generic.IEnumerable_string_,string,System.Net.Http.HttpClient).postPathTemplates'></a>

`postPathTemplates` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The path templates \(as written in the document\) that may be called with POST; every other POST is refused\.

<a name='DiGi.Harness.Classes.CallEndpointTool.CallEndpointTool(System.Uri,string,System.Text.Json.Nodes.JsonObject,System.Collections.Generic.IEnumerable_string_,string,System.Net.Http.HttpClient).bearerToken'></a>

`bearerToken` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The signed\-in user's bearer token, or null to call anonymously\.

<a name='DiGi.Harness.Classes.CallEndpointTool.CallEndpointTool(System.Uri,string,System.Text.Json.Nodes.JsonObject,System.Collections.Generic.IEnumerable_string_,string,System.Net.Http.HttpClient).httpClient'></a>

`httpClient` [System\.Net\.Http\.HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient 'System\.Net\.Http\.HttpClient')

The HTTP client; its timeout bounds each call\.
### Properties

<a name='DiGi.Harness.Classes.CallEndpointTool.ToolDefinition'></a>

## CallEndpointTool\.ToolDefinition Property

Gets the definition sent to the model\.

```csharp
public DiGi.Harness.Classes.ToolDefinition ToolDefinition { get; }
```

Implements [ToolDefinition](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.ITool.ToolDefinition 'DiGi\.Harness\.Interfaces\.ITool\.ToolDefinition')

#### Property Value
[ToolDefinition](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolDefinition 'DiGi\.Harness\.Classes\.ToolDefinition')
### Methods

<a name='DiGi.Harness.Classes.CallEndpointTool.InvokeAsync(DiGi.Harness.Classes.ToolUseContent,System.Threading.CancellationToken)'></a>

## CallEndpointTool\.InvokeAsync\(ToolUseContent, CancellationToken\) Method

Calls the endpoint named in the call's input and returns the status and body, or an error result when the call is refused or fails\.

```csharp
public System.Threading.Tasks.Task<DiGi.Harness.Classes.ToolResultContent> InvokeAsync(DiGi.Harness.Classes.ToolUseContent toolUseContent, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.Harness.Classes.CallEndpointTool.InvokeAsync(DiGi.Harness.Classes.ToolUseContent,System.Threading.CancellationToken).toolUseContent'></a>

`toolUseContent` [ToolUseContent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolUseContent 'DiGi\.Harness\.Classes\.ToolUseContent')

The call made by the model\.

<a name='DiGi.Harness.Classes.CallEndpointTool.InvokeAsync(DiGi.Harness.Classes.ToolUseContent,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token that cancels the call\.

Implements [InvokeAsync\(ToolUseContent, CancellationToken\)](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.ITool.InvokeAsync(DiGi.Harness.Classes.ToolUseContent,System.Threading.CancellationToken) 'DiGi\.Harness\.Interfaces\.ITool\.InvokeAsync\(DiGi\.Harness\.Classes\.ToolUseContent, System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ToolResultContent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolResultContent 'DiGi\.Harness\.Classes\.ToolResultContent')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The status line and the response body; an error result for a refused call, a failure status or no answer\.

<a name='DiGi.Harness.Classes.CompletionResult'></a>

## CompletionResult Class

The outcome of one streamed model request: the assistant message, how it stopped, its usage, or why it failed\.

```csharp
public class CompletionResult : DiGi.Harness.Interfaces.IHarnessObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.IResult
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CompletionResult

Implements [IHarnessObject](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IHarnessObject 'DiGi\.Harness\.Interfaces\.IHarnessObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.IResult](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iresult 'DiGi\.Core\.Interfaces\.IResult')
### Constructors

<a name='DiGi.Harness.Classes.CompletionResult.CompletionResult(DiGi.Harness.Classes.Message,DiGi.Harness.Enums.StopReason,DiGi.Harness.Classes.Usage,DiGi.Harness.Enums.ErrorCategory,string)'></a>

## CompletionResult\(Message, StopReason, Usage, ErrorCategory, string\) Constructor

Initializes a new instance of the [CompletionResult](DiGi.Harness.Classes.md#DiGi.Harness.Classes.CompletionResult 'DiGi\.Harness\.Classes\.CompletionResult') class\.

```csharp
public CompletionResult(DiGi.Harness.Classes.Message? message, DiGi.Harness.Enums.StopReason stopReason, DiGi.Harness.Classes.Usage? usage, DiGi.Harness.Enums.ErrorCategory errorCategory, string? errorMessage);
```
#### Parameters

<a name='DiGi.Harness.Classes.CompletionResult.CompletionResult(DiGi.Harness.Classes.Message,DiGi.Harness.Enums.StopReason,DiGi.Harness.Classes.Usage,DiGi.Harness.Enums.ErrorCategory,string).message'></a>

`message` [Message](DiGi.Harness.Classes.md#DiGi.Harness.Classes.Message 'DiGi\.Harness\.Classes\.Message')

The assistant message, or null when the request failed\.

<a name='DiGi.Harness.Classes.CompletionResult.CompletionResult(DiGi.Harness.Classes.Message,DiGi.Harness.Enums.StopReason,DiGi.Harness.Classes.Usage,DiGi.Harness.Enums.ErrorCategory,string).stopReason'></a>

`stopReason` [StopReason](DiGi.Harness.Enums.md#DiGi.Harness.Enums.StopReason 'DiGi\.Harness\.Enums\.StopReason')

The stop reason\.

<a name='DiGi.Harness.Classes.CompletionResult.CompletionResult(DiGi.Harness.Classes.Message,DiGi.Harness.Enums.StopReason,DiGi.Harness.Classes.Usage,DiGi.Harness.Enums.ErrorCategory,string).usage'></a>

`usage` [Usage](DiGi.Harness.Classes.md#DiGi.Harness.Classes.Usage 'DiGi\.Harness\.Classes\.Usage')

The token usage\.

<a name='DiGi.Harness.Classes.CompletionResult.CompletionResult(DiGi.Harness.Classes.Message,DiGi.Harness.Enums.StopReason,DiGi.Harness.Classes.Usage,DiGi.Harness.Enums.ErrorCategory,string).errorCategory'></a>

`errorCategory` [ErrorCategory](DiGi.Harness.Enums.md#DiGi.Harness.Enums.ErrorCategory 'DiGi\.Harness\.Enums\.ErrorCategory')

Why the request failed, or [Undefined](DiGi.Harness.Enums.md#DiGi.Harness.Enums.ErrorCategory.Undefined 'DiGi\.Harness\.Enums\.ErrorCategory\.Undefined')\.

<a name='DiGi.Harness.Classes.CompletionResult.CompletionResult(DiGi.Harness.Classes.Message,DiGi.Harness.Enums.StopReason,DiGi.Harness.Classes.Usage,DiGi.Harness.Enums.ErrorCategory,string).errorMessage'></a>

`errorMessage` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

A short, key\-free description of the failure\.
### Properties

<a name='DiGi.Harness.Classes.CompletionResult.ErrorCategory'></a>

## CompletionResult\.ErrorCategory Property

Gets why the request failed, or [Undefined](DiGi.Harness.Enums.md#DiGi.Harness.Enums.ErrorCategory.Undefined 'DiGi\.Harness\.Enums\.ErrorCategory\.Undefined')\.

```csharp
public DiGi.Harness.Enums.ErrorCategory ErrorCategory { get; }
```

#### Property Value
[ErrorCategory](DiGi.Harness.Enums.md#DiGi.Harness.Enums.ErrorCategory 'DiGi\.Harness\.Enums\.ErrorCategory')

<a name='DiGi.Harness.Classes.CompletionResult.ErrorMessage'></a>

## CompletionResult\.ErrorMessage Property

Gets a short, key\-free description of the failure\.

```csharp
public string? ErrorMessage { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Classes.CompletionResult.Message'></a>

## CompletionResult\.Message Property

Gets the assistant message, or null when the request failed\.

```csharp
public DiGi.Harness.Classes.Message? Message { get; }
```

#### Property Value
[Message](DiGi.Harness.Classes.md#DiGi.Harness.Classes.Message 'DiGi\.Harness\.Classes\.Message')

<a name='DiGi.Harness.Classes.CompletionResult.StopReason'></a>

## CompletionResult\.StopReason Property

Gets the stop reason\.

```csharp
public DiGi.Harness.Enums.StopReason StopReason { get; }
```

#### Property Value
[StopReason](DiGi.Harness.Enums.md#DiGi.Harness.Enums.StopReason 'DiGi\.Harness\.Enums\.StopReason')

<a name='DiGi.Harness.Classes.CompletionResult.Usage'></a>

## CompletionResult\.Usage Property

Gets the token usage\.

```csharp
public DiGi.Harness.Classes.Usage? Usage { get; }
```

#### Property Value
[Usage](DiGi.Harness.Classes.md#DiGi.Harness.Classes.Usage 'DiGi\.Harness\.Classes\.Usage')

<a name='DiGi.Harness.Classes.CompletionState'></a>

## CompletionState Class

The state of one streamed model response while it is being read\.

Filled by [Update\_Anthropic\(this CompletionState, JsonObject, double\)](DiGi.Harness.md#DiGi.Harness.Modify.Update_Anthropic(thisDiGi.Harness.Classes.CompletionState,System.Text.Json.Nodes.JsonObject,double) 'DiGi\.Harness\.Modify\.Update\_Anthropic\(this DiGi\.Harness\.Classes\.CompletionState, System\.Text\.Json\.Nodes\.JsonObject, double\)') or [Update\_OpenAI\(this CompletionState, JsonObject, double\)](DiGi.Harness.md#DiGi.Harness.Modify.Update_OpenAI(thisDiGi.Harness.Classes.CompletionState,System.Text.Json.Nodes.JsonObject,double) 'DiGi\.Harness\.Modify\.Update\_OpenAI\(this DiGi\.Harness\.Classes\.CompletionState, System\.Text\.Json\.Nodes\.JsonObject, double\)') and turned into a message by [ToHarness\_Message\(this CompletionState\)](DiGi.Harness.md#DiGi.Harness.Convert.ToHarness_Message(thisDiGi.Harness.Classes.CompletionState) 'DiGi\.Harness\.Convert\.ToHarness\_Message\(this DiGi\.Harness\.Classes\.CompletionState\)').

```csharp
public class CompletionState : DiGi.Harness.Interfaces.IHarnessObject, DiGi.Core.Interfaces.IObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CompletionState

Implements [IHarnessObject](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IHarnessObject 'DiGi\.Harness\.Interfaces\.IHarnessObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject')
### Constructors

<a name='DiGi.Harness.Classes.CompletionState.CompletionState(DiGi.Harness.Enums.Protocol)'></a>

## CompletionState\(Protocol\) Constructor

Initializes a new instance of the [CompletionState](DiGi.Harness.Classes.md#DiGi.Harness.Classes.CompletionState 'DiGi\.Harness\.Classes\.CompletionState') class\.

```csharp
public CompletionState(DiGi.Harness.Enums.Protocol protocol);
```
#### Parameters

<a name='DiGi.Harness.Classes.CompletionState.CompletionState(DiGi.Harness.Enums.Protocol).protocol'></a>

`protocol` [Protocol](DiGi.Harness.Enums.md#DiGi.Harness.Enums.Protocol 'DiGi\.Harness\.Enums\.Protocol')

The protocol of the stream\.
### Properties

<a name='DiGi.Harness.Classes.CompletionState.CacheCreationInputTokens'></a>

## CompletionState\.CacheCreationInputTokens Property

Gets or sets the input tokens written to the prompt cache\.

```csharp
public int CacheCreationInputTokens { get; set; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.Harness.Classes.CompletionState.CacheReadInputTokens'></a>

## CompletionState\.CacheReadInputTokens Property

Gets or sets the input tokens read from the prompt cache\.

```csharp
public int CacheReadInputTokens { get; set; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.Harness.Classes.CompletionState.ContentStates'></a>

## CompletionState\.ContentStates Property

Gets the content blocks keyed by their position: the Anthropic block index, or for OpenAI 0 for reasoning, 1 for text and 2 \+ index for tool calls\.

```csharp
public System.Collections.Generic.SortedDictionary<int,DiGi.Harness.Classes.ContentState> ContentStates { get; }
```

#### Property Value
[System\.Collections\.Generic\.SortedDictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.sorteddictionary-2 'System\.Collections\.Generic\.SortedDictionary\`2')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.sorteddictionary-2 'System\.Collections\.Generic\.SortedDictionary\`2')[ContentState](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ContentState 'DiGi\.Harness\.Classes\.ContentState')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.sorteddictionary-2 'System\.Collections\.Generic\.SortedDictionary\`2')

<a name='DiGi.Harness.Classes.CompletionState.ErrorMessage'></a>

## CompletionState\.ErrorMessage Property

Gets or sets the error reported inside the stream, or null\.

```csharp
public string? ErrorMessage { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Classes.CompletionState.InputTokens'></a>

## CompletionState\.InputTokens Property

Gets or sets the uncached input tokens\.

```csharp
public int InputTokens { get; set; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.Harness.Classes.CompletionState.OutputTokens'></a>

## CompletionState\.OutputTokens Property

Gets or sets the output tokens\.

```csharp
public int OutputTokens { get; set; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.Harness.Classes.CompletionState.Protocol'></a>

## CompletionState\.Protocol Property

Gets the protocol of the stream\.

```csharp
public DiGi.Harness.Enums.Protocol Protocol { get; }
```

#### Property Value
[Protocol](DiGi.Harness.Enums.md#DiGi.Harness.Enums.Protocol 'DiGi\.Harness\.Enums\.Protocol')

<a name='DiGi.Harness.Classes.CompletionState.RefusalMessage'></a>

## CompletionState\.RefusalMessage Property

Gets or sets the refusal explanation reported with a refusal stop reason, or null\.

```csharp
public string? RefusalMessage { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Classes.CompletionState.StopReason'></a>

## CompletionState\.StopReason Property

Gets or sets the stop reason\.

```csharp
public DiGi.Harness.Enums.StopReason StopReason { get; set; }
```

#### Property Value
[StopReason](DiGi.Harness.Enums.md#DiGi.Harness.Enums.StopReason 'DiGi\.Harness\.Enums\.StopReason')

<a name='DiGi.Harness.Classes.ContentState'></a>

## ContentState Class

One content block being accumulated from a streamed response\.

```csharp
public class ContentState : DiGi.Harness.Interfaces.IHarnessObject, DiGi.Core.Interfaces.IObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ContentState

Implements [IHarnessObject](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IHarnessObject 'DiGi\.Harness\.Interfaces\.IHarnessObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject')
### Constructors

<a name='DiGi.Harness.Classes.ContentState.ContentState(DiGi.Harness.Enums.ContentKind)'></a>

## ContentState\(ContentKind\) Constructor

Initializes a new instance of the [ContentState](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ContentState 'DiGi\.Harness\.Classes\.ContentState') class\.

```csharp
public ContentState(DiGi.Harness.Enums.ContentKind contentKind);
```
#### Parameters

<a name='DiGi.Harness.Classes.ContentState.ContentState(DiGi.Harness.Enums.ContentKind).contentKind'></a>

`contentKind` [ContentKind](DiGi.Harness.Enums.md#DiGi.Harness.Enums.ContentKind 'DiGi\.Harness\.Enums\.ContentKind')

The kind of block\.
### Properties

<a name='DiGi.Harness.Classes.ContentState.Completed'></a>

## ContentState\.Completed Property

Gets or sets a value indicating whether the block is complete\.

```csharp
public bool Completed { get; set; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.Harness.Classes.ContentState.ContentKind'></a>

## ContentState\.ContentKind Property

Gets the kind of block\.

```csharp
public DiGi.Harness.Enums.ContentKind ContentKind { get; }
```

#### Property Value
[ContentKind](DiGi.Harness.Enums.md#DiGi.Harness.Enums.ContentKind 'DiGi\.Harness\.Enums\.ContentKind')

<a name='DiGi.Harness.Classes.ContentState.Id'></a>

## ContentState\.Id Property

Gets or sets the identifier of a tool call\.

```csharp
public string? Id { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Classes.ContentState.Name'></a>

## ContentState\.Name Property

Gets or sets the tool name of a tool call\.

```csharp
public string? Name { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Classes.ContentState.RedactedData'></a>

## ContentState\.RedactedData Property

Gets or sets the opaque data of a redacted thinking block\.

```csharp
public string? RedactedData { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Classes.ContentState.Signature'></a>

## ContentState\.Signature Property

Gets or sets the Anthropic signature of a thinking block\.

```csharp
public string? Signature { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Classes.ContentState.StringBuilder'></a>

## ContentState\.StringBuilder Property

Gets the accumulated text: answer text, thinking text, or the tool input JSON\.

```csharp
public System.Text.StringBuilder StringBuilder { get; }
```

#### Property Value
[System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder')

<a name='DiGi.Harness.Classes.Conversation'></a>

## Conversation Class

A conversation with one provider: the ordered messages exchanged so far\.

The history is append-only ([Add\(this Conversation, Message\)](DiGi.Harness.md#DiGi.Harness.Modify.Add(thisDiGi.Harness.Classes.Conversation,DiGi.Harness.Classes.Message) 'DiGi\.Harness\.Modify\.Add\(this DiGi\.Harness\.Classes\.Conversation, DiGi\.Harness\.Classes\.Message\)')): Anthropic thinking blocks are valid only in the exact conversation that produced them, so a message is never edited or removed once added.

```csharp
public class Conversation : DiGi.Core.Classes.SerializableObject, DiGi.Harness.Interfaces.IHarnessSerializableObject, DiGi.Harness.Interfaces.IHarnessObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → Conversation

Implements [IHarnessSerializableObject](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IHarnessSerializableObject 'DiGi\.Harness\.Interfaces\.IHarnessSerializableObject'), [IHarnessObject](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IHarnessObject 'DiGi\.Harness\.Interfaces\.IHarnessObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Harness.Classes.Conversation.Conversation(DiGi.Harness.Classes.Conversation)'></a>

## Conversation\(Conversation\) Constructor

Initializes a new instance of the [Conversation](DiGi.Harness.Classes.md#DiGi.Harness.Classes.Conversation 'DiGi\.Harness\.Classes\.Conversation') class by copying another instance\.

```csharp
public Conversation(DiGi.Harness.Classes.Conversation? conversation);
```
#### Parameters

<a name='DiGi.Harness.Classes.Conversation.Conversation(DiGi.Harness.Classes.Conversation).conversation'></a>

`conversation` [Conversation](DiGi.Harness.Classes.md#DiGi.Harness.Classes.Conversation 'DiGi\.Harness\.Classes\.Conversation')

The instance to copy from\.

<a name='DiGi.Harness.Classes.Conversation.Conversation(string,System.Collections.Generic.IEnumerable_DiGi.Harness.Classes.Message_)'></a>

## Conversation\(string, IEnumerable\<Message\>\) Constructor

Initializes a new instance of the [Conversation](DiGi.Harness.Classes.md#DiGi.Harness.Classes.Conversation 'DiGi\.Harness\.Classes\.Conversation') class\.

```csharp
public Conversation(string? providerName, System.Collections.Generic.IEnumerable<DiGi.Harness.Classes.Message>? messages);
```
#### Parameters

<a name='DiGi.Harness.Classes.Conversation.Conversation(string,System.Collections.Generic.IEnumerable_DiGi.Harness.Classes.Message_).providerName'></a>

`providerName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the provider the conversation is locked to\.

<a name='DiGi.Harness.Classes.Conversation.Conversation(string,System.Collections.Generic.IEnumerable_DiGi.Harness.Classes.Message_).messages'></a>

`messages` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[Message](DiGi.Harness.Classes.md#DiGi.Harness.Classes.Message 'DiGi\.Harness\.Classes\.Message')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The messages exchanged so far\.

<a name='DiGi.Harness.Classes.Conversation.Conversation(System.Text.Json.Nodes.JsonObject)'></a>

## Conversation\(JsonObject\) Constructor

Initializes a new instance of the [Conversation](DiGi.Harness.Classes.md#DiGi.Harness.Classes.Conversation 'DiGi\.Harness\.Classes\.Conversation') class from a JSON object\.

```csharp
public Conversation(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Harness.Classes.Conversation.Conversation(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object to read from\.
### Properties

<a name='DiGi.Harness.Classes.Conversation.Messages'></a>

## Conversation\.Messages Property

Gets the messages exchanged so far\.

```csharp
public System.Collections.Generic.IReadOnlyList<DiGi.Harness.Classes.Message> Messages { get; }
```

#### Property Value
[System\.Collections\.Generic\.IReadOnlyList&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')[Message](DiGi.Harness.Classes.md#DiGi.Harness.Classes.Message 'DiGi\.Harness\.Classes\.Message')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')

<a name='DiGi.Harness.Classes.Conversation.ProviderName'></a>

## Conversation\.ProviderName Property

Gets the name of the provider the conversation is locked to\.

```csharp
public string? ProviderName { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')
### Methods

<a name='DiGi.Harness.Classes.Conversation.Append(DiGi.Harness.Classes.Message)'></a>

## Conversation\.Append\(Message\) Method

Appends a message; the only mutation the history allows\.

```csharp
internal void Append(DiGi.Harness.Classes.Message message);
```
#### Parameters

<a name='DiGi.Harness.Classes.Conversation.Append(DiGi.Harness.Classes.Message).message'></a>

`message` [Message](DiGi.Harness.Classes.md#DiGi.Harness.Classes.Message 'DiGi\.Harness\.Classes\.Message')

The message to append\.

<a name='DiGi.Harness.Classes.DescribeEndpointTool'></a>

## DescribeEndpointTool Class

The `describe_endpoint` tool: returns one WebAPI operation's description, parameters, request body and response schemas from an OpenAPI document\.

```csharp
public class DescribeEndpointTool : DiGi.Harness.Interfaces.ITool, DiGi.Harness.Interfaces.IHarnessObject, DiGi.Core.Interfaces.IObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → DescribeEndpointTool

Implements [ITool](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.ITool 'DiGi\.Harness\.Interfaces\.ITool'), [IHarnessObject](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IHarnessObject 'DiGi\.Harness\.Interfaces\.IHarnessObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject')
### Constructors

<a name='DiGi.Harness.Classes.DescribeEndpointTool.DescribeEndpointTool(System.Text.Json.Nodes.JsonObject,string)'></a>

## DescribeEndpointTool\(JsonObject, string\) Constructor

Initializes a new instance of the [DescribeEndpointTool](DiGi.Harness.Classes.md#DiGi.Harness.Classes.DescribeEndpointTool 'DiGi\.Harness\.Classes\.DescribeEndpointTool') class\.

```csharp
public DescribeEndpointTool(System.Text.Json.Nodes.JsonObject? swagger, string? pathPrefix);
```
#### Parameters

<a name='DiGi.Harness.Classes.DescribeEndpointTool.DescribeEndpointTool(System.Text.Json.Nodes.JsonObject,string).swagger'></a>

`swagger` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The OpenAPI document\.

<a name='DiGi.Harness.Classes.DescribeEndpointTool.DescribeEndpointTool(System.Text.Json.Nodes.JsonObject,string).pathPrefix'></a>

`pathPrefix` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path prefix the model may ask about, such as `/gis/`; null allows every path of the document\.
### Properties

<a name='DiGi.Harness.Classes.DescribeEndpointTool.ToolDefinition'></a>

## DescribeEndpointTool\.ToolDefinition Property

Gets the definition sent to the model\.

```csharp
public DiGi.Harness.Classes.ToolDefinition ToolDefinition { get; }
```

Implements [ToolDefinition](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.ITool.ToolDefinition 'DiGi\.Harness\.Interfaces\.ITool\.ToolDefinition')

#### Property Value
[ToolDefinition](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolDefinition 'DiGi\.Harness\.Classes\.ToolDefinition')
### Methods

<a name='DiGi.Harness.Classes.DescribeEndpointTool.InvokeAsync(DiGi.Harness.Classes.ToolUseContent,System.Threading.CancellationToken)'></a>

## DescribeEndpointTool\.InvokeAsync\(ToolUseContent, CancellationToken\) Method

Returns the description of the endpoint named in the call's input, or an error result when it is unknown\.

```csharp
public System.Threading.Tasks.Task<DiGi.Harness.Classes.ToolResultContent> InvokeAsync(DiGi.Harness.Classes.ToolUseContent toolUseContent, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.Harness.Classes.DescribeEndpointTool.InvokeAsync(DiGi.Harness.Classes.ToolUseContent,System.Threading.CancellationToken).toolUseContent'></a>

`toolUseContent` [ToolUseContent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolUseContent 'DiGi\.Harness\.Classes\.ToolUseContent')

The call made by the model\.

<a name='DiGi.Harness.Classes.DescribeEndpointTool.InvokeAsync(DiGi.Harness.Classes.ToolUseContent,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token that cancels the call \(unused; the lookup is synchronous\)\.

Implements [InvokeAsync\(ToolUseContent, CancellationToken\)](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.ITool.InvokeAsync(DiGi.Harness.Classes.ToolUseContent,System.Threading.CancellationToken) 'DiGi\.Harness\.Interfaces\.ITool\.InvokeAsync\(DiGi\.Harness\.Classes\.ToolUseContent, System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ToolResultContent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolResultContent 'DiGi\.Harness\.Classes\.ToolResultContent')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The endpoint description as JSON text, or an error result\.

<a name='DiGi.Harness.Classes.ErrorEvent'></a>

## ErrorEvent Class

The turn failed; carries the category and a short, key\-free message\.

```csharp
public class ErrorEvent : DiGi.Harness.Classes.HarnessEvent
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [HarnessEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.HarnessEvent 'DiGi\.Harness\.Classes\.HarnessEvent') → ErrorEvent
### Constructors

<a name='DiGi.Harness.Classes.ErrorEvent.ErrorEvent(DiGi.Harness.Classes.ErrorEvent)'></a>

## ErrorEvent\(ErrorEvent\) Constructor

Initializes a new instance of the [ErrorEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ErrorEvent 'DiGi\.Harness\.Classes\.ErrorEvent') class by copying another instance\.

```csharp
public ErrorEvent(DiGi.Harness.Classes.ErrorEvent? errorEvent);
```
#### Parameters

<a name='DiGi.Harness.Classes.ErrorEvent.ErrorEvent(DiGi.Harness.Classes.ErrorEvent).errorEvent'></a>

`errorEvent` [ErrorEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ErrorEvent 'DiGi\.Harness\.Classes\.ErrorEvent')

The instance to copy from\.

<a name='DiGi.Harness.Classes.ErrorEvent.ErrorEvent(DiGi.Harness.Enums.ErrorCategory,string,double)'></a>

## ErrorEvent\(ErrorCategory, string, double\) Constructor

Initializes a new instance of the [ErrorEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ErrorEvent 'DiGi\.Harness\.Classes\.ErrorEvent') class\.

```csharp
public ErrorEvent(DiGi.Harness.Enums.ErrorCategory errorCategory, string? message, double elapsedMilliseconds);
```
#### Parameters

<a name='DiGi.Harness.Classes.ErrorEvent.ErrorEvent(DiGi.Harness.Enums.ErrorCategory,string,double).errorCategory'></a>

`errorCategory` [ErrorCategory](DiGi.Harness.Enums.md#DiGi.Harness.Enums.ErrorCategory 'DiGi\.Harness\.Enums\.ErrorCategory')

Why the turn failed\.

<a name='DiGi.Harness.Classes.ErrorEvent.ErrorEvent(DiGi.Harness.Enums.ErrorCategory,string,double).message'></a>

`message` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

A short, key\-free description\.

<a name='DiGi.Harness.Classes.ErrorEvent.ErrorEvent(DiGi.Harness.Enums.ErrorCategory,string,double).elapsedMilliseconds'></a>

`elapsedMilliseconds` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The time elapsed since the turn started, in milliseconds\.

<a name='DiGi.Harness.Classes.ErrorEvent.ErrorEvent(System.Text.Json.Nodes.JsonObject)'></a>

## ErrorEvent\(JsonObject\) Constructor

Initializes a new instance of the [ErrorEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ErrorEvent 'DiGi\.Harness\.Classes\.ErrorEvent') class from a JSON object\.

```csharp
public ErrorEvent(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Harness.Classes.ErrorEvent.ErrorEvent(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object to read from\.
### Properties

<a name='DiGi.Harness.Classes.ErrorEvent.ErrorCategory'></a>

## ErrorEvent\.ErrorCategory Property

Gets why the turn failed\.

```csharp
public DiGi.Harness.Enums.ErrorCategory ErrorCategory { get; }
```

#### Property Value
[ErrorCategory](DiGi.Harness.Enums.md#DiGi.Harness.Enums.ErrorCategory 'DiGi\.Harness\.Enums\.ErrorCategory')

<a name='DiGi.Harness.Classes.ErrorEvent.Message'></a>

## ErrorEvent\.Message Property

Gets a short, key\-free description\.

```csharp
public string? Message { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Classes.HarnessConfiguration'></a>

## HarnessConfiguration Class

The harness configuration: whether it is enabled, the providers, and the limits of one turn\.

Denies by default: a missing file or [Enabled](DiGi.Harness.Classes.md#DiGi.Harness.Classes.HarnessConfiguration.Enabled 'DiGi\.Harness\.Classes\.HarnessConfiguration\.Enabled') false turns the harness off. The committed `files/Harness.json` ships disabled and without keys; the real one belongs in `user files/`.

```csharp
public class HarnessConfiguration : DiGi.Core.Classes.SerializableObject, DiGi.Harness.Interfaces.IHarnessSerializableObject, DiGi.Harness.Interfaces.IHarnessObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → HarnessConfiguration

Implements [IHarnessSerializableObject](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IHarnessSerializableObject 'DiGi\.Harness\.Interfaces\.IHarnessSerializableObject'), [IHarnessObject](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IHarnessObject 'DiGi\.Harness\.Interfaces\.IHarnessObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Harness.Classes.HarnessConfiguration.HarnessConfiguration(bool,string,System.Collections.Generic.IEnumerable_DiGi.Harness.Classes.ProviderConfiguration_,int,int,int,System.Collections.Generic.IEnumerable_string_)'></a>

## HarnessConfiguration\(bool, string, IEnumerable\<ProviderConfiguration\>, int, int, int, IEnumerable\<string\>\) Constructor

Initializes a new instance of the [HarnessConfiguration](DiGi.Harness.Classes.md#DiGi.Harness.Classes.HarnessConfiguration 'DiGi\.Harness\.Classes\.HarnessConfiguration') class\.

```csharp
public HarnessConfiguration(bool enabled, string? defaultProviderName, System.Collections.Generic.IEnumerable<DiGi.Harness.Classes.ProviderConfiguration>? providers, int maxToolIterations, int maxToolResultCharacters, int requestTimeoutSeconds, System.Collections.Generic.IEnumerable<string>? allowedUserIds);
```
#### Parameters

<a name='DiGi.Harness.Classes.HarnessConfiguration.HarnessConfiguration(bool,string,System.Collections.Generic.IEnumerable_DiGi.Harness.Classes.ProviderConfiguration_,int,int,int,System.Collections.Generic.IEnumerable_string_).enabled'></a>

`enabled` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether the harness is enabled\.

<a name='DiGi.Harness.Classes.HarnessConfiguration.HarnessConfiguration(bool,string,System.Collections.Generic.IEnumerable_DiGi.Harness.Classes.ProviderConfiguration_,int,int,int,System.Collections.Generic.IEnumerable_string_).defaultProviderName'></a>

`defaultProviderName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the provider selected for a new session\.

<a name='DiGi.Harness.Classes.HarnessConfiguration.HarnessConfiguration(bool,string,System.Collections.Generic.IEnumerable_DiGi.Harness.Classes.ProviderConfiguration_,int,int,int,System.Collections.Generic.IEnumerable_string_).providers'></a>

`providers` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[ProviderConfiguration](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ProviderConfiguration 'DiGi\.Harness\.Classes\.ProviderConfiguration')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The providers\.

<a name='DiGi.Harness.Classes.HarnessConfiguration.HarnessConfiguration(bool,string,System.Collections.Generic.IEnumerable_DiGi.Harness.Classes.ProviderConfiguration_,int,int,int,System.Collections.Generic.IEnumerable_string_).maxToolIterations'></a>

`maxToolIterations` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The maximum number of model requests in one turn; zero or less uses the default\.

<a name='DiGi.Harness.Classes.HarnessConfiguration.HarnessConfiguration(bool,string,System.Collections.Generic.IEnumerable_DiGi.Harness.Classes.ProviderConfiguration_,int,int,int,System.Collections.Generic.IEnumerable_string_).maxToolResultCharacters'></a>

`maxToolResultCharacters` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The maximum number of characters of one tool result; zero or less uses the default\.

<a name='DiGi.Harness.Classes.HarnessConfiguration.HarnessConfiguration(bool,string,System.Collections.Generic.IEnumerable_DiGi.Harness.Classes.ProviderConfiguration_,int,int,int,System.Collections.Generic.IEnumerable_string_).requestTimeoutSeconds'></a>

`requestTimeoutSeconds` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The timeout of one model request in seconds; zero or less uses the default\.

<a name='DiGi.Harness.Classes.HarnessConfiguration.HarnessConfiguration(bool,string,System.Collections.Generic.IEnumerable_DiGi.Harness.Classes.ProviderConfiguration_,int,int,int,System.Collections.Generic.IEnumerable_string_).allowedUserIds'></a>

`allowedUserIds` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The users allowed to chat; null or empty allows every signed\-in user\.

<a name='DiGi.Harness.Classes.HarnessConfiguration.HarnessConfiguration(DiGi.Harness.Classes.HarnessConfiguration)'></a>

## HarnessConfiguration\(HarnessConfiguration\) Constructor

Initializes a new instance of the [HarnessConfiguration](DiGi.Harness.Classes.md#DiGi.Harness.Classes.HarnessConfiguration 'DiGi\.Harness\.Classes\.HarnessConfiguration') class by copying another instance\.

```csharp
public HarnessConfiguration(DiGi.Harness.Classes.HarnessConfiguration? harnessConfiguration);
```
#### Parameters

<a name='DiGi.Harness.Classes.HarnessConfiguration.HarnessConfiguration(DiGi.Harness.Classes.HarnessConfiguration).harnessConfiguration'></a>

`harnessConfiguration` [HarnessConfiguration](DiGi.Harness.Classes.md#DiGi.Harness.Classes.HarnessConfiguration 'DiGi\.Harness\.Classes\.HarnessConfiguration')

The instance to copy from\.

<a name='DiGi.Harness.Classes.HarnessConfiguration.HarnessConfiguration(System.Text.Json.Nodes.JsonObject)'></a>

## HarnessConfiguration\(JsonObject\) Constructor

Initializes a new instance of the [HarnessConfiguration](DiGi.Harness.Classes.md#DiGi.Harness.Classes.HarnessConfiguration 'DiGi\.Harness\.Classes\.HarnessConfiguration') class from a JSON object\.

```csharp
public HarnessConfiguration(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Harness.Classes.HarnessConfiguration.HarnessConfiguration(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object to read from\.
### Properties

<a name='DiGi.Harness.Classes.HarnessConfiguration.AllowedUserIds'></a>

## HarnessConfiguration\.AllowedUserIds Property

Gets the users allowed to chat; null or empty allows every signed\-in user\.

```csharp
public System.Collections.Generic.IReadOnlyList<string>? AllowedUserIds { get; }
```

#### Property Value
[System\.Collections\.Generic\.IReadOnlyList&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')

<a name='DiGi.Harness.Classes.HarnessConfiguration.DefaultProviderName'></a>

## HarnessConfiguration\.DefaultProviderName Property

Gets the name of the provider selected for a new session\.

```csharp
public string? DefaultProviderName { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Classes.HarnessConfiguration.Enabled'></a>

## HarnessConfiguration\.Enabled Property

Gets a value indicating whether the harness is enabled; false turns every chat endpoint off\.

```csharp
public bool Enabled { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.Harness.Classes.HarnessConfiguration.MaxToolIterations'></a>

## HarnessConfiguration\.MaxToolIterations Property

Gets the maximum number of model requests in one turn; zero or less uses the default\.

```csharp
public int MaxToolIterations { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.Harness.Classes.HarnessConfiguration.MaxToolResultCharacters'></a>

## HarnessConfiguration\.MaxToolResultCharacters Property

Gets the maximum number of characters of one tool result; zero or less uses the default\.

```csharp
public int MaxToolResultCharacters { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.Harness.Classes.HarnessConfiguration.Providers'></a>

## HarnessConfiguration\.Providers Property

Gets the providers\.

```csharp
public System.Collections.Generic.IReadOnlyList<DiGi.Harness.Classes.ProviderConfiguration>? Providers { get; }
```

#### Property Value
[System\.Collections\.Generic\.IReadOnlyList&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')[ProviderConfiguration](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ProviderConfiguration 'DiGi\.Harness\.Classes\.ProviderConfiguration')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')

<a name='DiGi.Harness.Classes.HarnessConfiguration.RequestTimeoutSeconds'></a>

## HarnessConfiguration\.RequestTimeoutSeconds Property

Gets the timeout of one model request in seconds; zero or less uses the default\.

```csharp
public int RequestTimeoutSeconds { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.Harness.Classes.HarnessEvent'></a>

## HarnessEvent Class

The base of every event emitted while a turn runs\.

Clients tell events apart by the serialized type name (`_type`), so the names of the derived classes are a wire contract.

```csharp
public abstract class HarnessEvent : DiGi.Core.Classes.SerializableObject, DiGi.Harness.Interfaces.IHarnessEvent, DiGi.Harness.Interfaces.IHarnessSerializableObject, DiGi.Harness.Interfaces.IHarnessObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → HarnessEvent

Derived  
↳ [ErrorEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ErrorEvent 'DiGi\.Harness\.Classes\.ErrorEvent')  
↳ [StepStartedEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.StepStartedEvent 'DiGi\.Harness\.Classes\.StepStartedEvent')  
↳ [TextDeltaEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.TextDeltaEvent 'DiGi\.Harness\.Classes\.TextDeltaEvent')  
↳ [ThinkingCompletedEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ThinkingCompletedEvent 'DiGi\.Harness\.Classes\.ThinkingCompletedEvent')  
↳ [ThinkingDeltaEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ThinkingDeltaEvent 'DiGi\.Harness\.Classes\.ThinkingDeltaEvent')  
↳ [ThinkingSummaryEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ThinkingSummaryEvent 'DiGi\.Harness\.Classes\.ThinkingSummaryEvent')  
↳ [ToolCallCompletedEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolCallCompletedEvent 'DiGi\.Harness\.Classes\.ToolCallCompletedEvent')  
↳ [ToolCallStartedEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolCallStartedEvent 'DiGi\.Harness\.Classes\.ToolCallStartedEvent')  
↳ [TurnCompletedEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.TurnCompletedEvent 'DiGi\.Harness\.Classes\.TurnCompletedEvent')  
↳ [UsageEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.UsageEvent 'DiGi\.Harness\.Classes\.UsageEvent')

Implements [IHarnessEvent](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IHarnessEvent 'DiGi\.Harness\.Interfaces\.IHarnessEvent'), [IHarnessSerializableObject](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IHarnessSerializableObject 'DiGi\.Harness\.Interfaces\.IHarnessSerializableObject'), [IHarnessObject](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IHarnessObject 'DiGi\.Harness\.Interfaces\.IHarnessObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Harness.Classes.HarnessEvent.HarnessEvent(DiGi.Harness.Classes.HarnessEvent)'></a>

## HarnessEvent\(HarnessEvent\) Constructor

Initializes a new instance of the [HarnessEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.HarnessEvent 'DiGi\.Harness\.Classes\.HarnessEvent') class by copying another instance\.

```csharp
protected HarnessEvent(DiGi.Harness.Classes.HarnessEvent? harnessEvent);
```
#### Parameters

<a name='DiGi.Harness.Classes.HarnessEvent.HarnessEvent(DiGi.Harness.Classes.HarnessEvent).harnessEvent'></a>

`harnessEvent` [HarnessEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.HarnessEvent 'DiGi\.Harness\.Classes\.HarnessEvent')

The instance to copy from\.

<a name='DiGi.Harness.Classes.HarnessEvent.HarnessEvent(double)'></a>

## HarnessEvent\(double\) Constructor

Initializes a new instance of the [HarnessEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.HarnessEvent 'DiGi\.Harness\.Classes\.HarnessEvent') class\.

```csharp
protected HarnessEvent(double elapsedMilliseconds);
```
#### Parameters

<a name='DiGi.Harness.Classes.HarnessEvent.HarnessEvent(double).elapsedMilliseconds'></a>

`elapsedMilliseconds` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The time elapsed since the turn started, in milliseconds\.

<a name='DiGi.Harness.Classes.HarnessEvent.HarnessEvent(System.Text.Json.Nodes.JsonObject)'></a>

## HarnessEvent\(JsonObject\) Constructor

Initializes a new instance of the [HarnessEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.HarnessEvent 'DiGi\.Harness\.Classes\.HarnessEvent') class from a JSON object\.

```csharp
protected HarnessEvent(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Harness.Classes.HarnessEvent.HarnessEvent(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object to read from\.
### Properties

<a name='DiGi.Harness.Classes.HarnessEvent.ElapsedMilliseconds'></a>

## HarnessEvent\.ElapsedMilliseconds Property

Gets the time elapsed since the turn started, in milliseconds\.

```csharp
public double ElapsedMilliseconds { get; }
```

Implements [ElapsedMilliseconds](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IHarnessEvent.ElapsedMilliseconds 'DiGi\.Harness\.Interfaces\.IHarnessEvent\.ElapsedMilliseconds')

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Harness.Classes.Message'></a>

## Message Class

One message of a conversation: a role and its content blocks\.

```csharp
public class Message : DiGi.Core.Classes.SerializableObject, DiGi.Harness.Interfaces.IHarnessSerializableObject, DiGi.Harness.Interfaces.IHarnessObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → Message

Implements [IHarnessSerializableObject](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IHarnessSerializableObject 'DiGi\.Harness\.Interfaces\.IHarnessSerializableObject'), [IHarnessObject](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IHarnessObject 'DiGi\.Harness\.Interfaces\.IHarnessObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Harness.Classes.Message.Message(DiGi.Harness.Classes.Message)'></a>

## Message\(Message\) Constructor

Initializes a new instance of the [Message](DiGi.Harness.Classes.md#DiGi.Harness.Classes.Message 'DiGi\.Harness\.Classes\.Message') class by copying another instance\.

```csharp
public Message(DiGi.Harness.Classes.Message? message);
```
#### Parameters

<a name='DiGi.Harness.Classes.Message.Message(DiGi.Harness.Classes.Message).message'></a>

`message` [Message](DiGi.Harness.Classes.md#DiGi.Harness.Classes.Message 'DiGi\.Harness\.Classes\.Message')

The instance to copy from\.

<a name='DiGi.Harness.Classes.Message.Message(DiGi.Harness.Enums.Role,System.Collections.Generic.IEnumerable_DiGi.Harness.Interfaces.IContent_)'></a>

## Message\(Role, IEnumerable\<IContent\>\) Constructor

Initializes a new instance of the [Message](DiGi.Harness.Classes.md#DiGi.Harness.Classes.Message 'DiGi\.Harness\.Classes\.Message') class\.

```csharp
public Message(DiGi.Harness.Enums.Role role, System.Collections.Generic.IEnumerable<DiGi.Harness.Interfaces.IContent>? contents);
```
#### Parameters

<a name='DiGi.Harness.Classes.Message.Message(DiGi.Harness.Enums.Role,System.Collections.Generic.IEnumerable_DiGi.Harness.Interfaces.IContent_).role'></a>

`role` [Role](DiGi.Harness.Enums.md#DiGi.Harness.Enums.Role 'DiGi\.Harness\.Enums\.Role')

The author of the message\.

<a name='DiGi.Harness.Classes.Message.Message(DiGi.Harness.Enums.Role,System.Collections.Generic.IEnumerable_DiGi.Harness.Interfaces.IContent_).contents'></a>

`contents` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[IContent](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IContent 'DiGi\.Harness\.Interfaces\.IContent')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The content blocks, in order\.

<a name='DiGi.Harness.Classes.Message.Message(System.Text.Json.Nodes.JsonObject)'></a>

## Message\(JsonObject\) Constructor

Initializes a new instance of the [Message](DiGi.Harness.Classes.md#DiGi.Harness.Classes.Message 'DiGi\.Harness\.Classes\.Message') class from a JSON object\.

```csharp
public Message(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Harness.Classes.Message.Message(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object to read from\.
### Properties

<a name='DiGi.Harness.Classes.Message.Contents'></a>

## Message\.Contents Property

Gets the content blocks, in order\.

```csharp
public System.Collections.Generic.IReadOnlyList<DiGi.Harness.Interfaces.IContent>? Contents { get; }
```

#### Property Value
[System\.Collections\.Generic\.IReadOnlyList&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')[IContent](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IContent 'DiGi\.Harness\.Interfaces\.IContent')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')

<a name='DiGi.Harness.Classes.Message.Role'></a>

## Message\.Role Property

Gets the author of the message\.

```csharp
public DiGi.Harness.Enums.Role Role { get; }
```

#### Property Value
[Role](DiGi.Harness.Enums.md#DiGi.Harness.Enums.Role 'DiGi\.Harness\.Enums\.Role')

<a name='DiGi.Harness.Classes.ProviderConfiguration'></a>

## ProviderConfiguration Class

One model provider: where it is, which protocol it speaks, which model it runs and how it is called\.

Anthropic, DeepSeek, Xiaomi MiMo, LM Studio and Strata are all configured with this one type; only [Protocol](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ProviderConfiguration.Protocol 'DiGi\.Harness\.Classes\.ProviderConfiguration\.Protocol'), [BaseUri](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ProviderConfiguration.BaseUri 'DiGi\.Harness\.Classes\.ProviderConfiguration\.BaseUri') and [Model](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ProviderConfiguration.Model 'DiGi\.Harness\.Classes\.ProviderConfiguration\.Model') differ.

```csharp
public class ProviderConfiguration : DiGi.Core.Classes.SerializableObject, DiGi.Harness.Interfaces.IHarnessSerializableObject, DiGi.Harness.Interfaces.IHarnessObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → ProviderConfiguration

Implements [IHarnessSerializableObject](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IHarnessSerializableObject 'DiGi\.Harness\.Interfaces\.IHarnessSerializableObject'), [IHarnessObject](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IHarnessObject 'DiGi\.Harness\.Interfaces\.IHarnessObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Harness.Classes.ProviderConfiguration.ProviderConfiguration(DiGi.Harness.Classes.ProviderConfiguration)'></a>

## ProviderConfiguration\(ProviderConfiguration\) Constructor

Initializes a new instance of the [ProviderConfiguration](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ProviderConfiguration 'DiGi\.Harness\.Classes\.ProviderConfiguration') class by copying another instance\.

```csharp
public ProviderConfiguration(DiGi.Harness.Classes.ProviderConfiguration? providerConfiguration);
```
#### Parameters

<a name='DiGi.Harness.Classes.ProviderConfiguration.ProviderConfiguration(DiGi.Harness.Classes.ProviderConfiguration).providerConfiguration'></a>

`providerConfiguration` [ProviderConfiguration](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ProviderConfiguration 'DiGi\.Harness\.Classes\.ProviderConfiguration')

The instance to copy from\.

<a name='DiGi.Harness.Classes.ProviderConfiguration.ProviderConfiguration(string,string,DiGi.Harness.Enums.Protocol,string,string,string,string,int,string,bool,bool,bool,bool)'></a>

## ProviderConfiguration\(string, string, Protocol, string, string, string, string, int, string, bool, bool, bool, bool\) Constructor

Initializes a new instance of the [ProviderConfiguration](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ProviderConfiguration 'DiGi\.Harness\.Classes\.ProviderConfiguration') class\.

```csharp
public ProviderConfiguration(string? name, string? displayName, DiGi.Harness.Enums.Protocol protocol, string? baseUri, string? model, string? key, string? keyEnvironmentVariable, int maxTokens, string? effort, bool thinking, bool replayReasoning, bool anthropicFallbacks, bool enabled);
```
#### Parameters

<a name='DiGi.Harness.Classes.ProviderConfiguration.ProviderConfiguration(string,string,DiGi.Harness.Enums.Protocol,string,string,string,string,int,string,bool,bool,bool,bool).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The unique name clients select the provider by\.

<a name='DiGi.Harness.Classes.ProviderConfiguration.ProviderConfiguration(string,string,DiGi.Harness.Enums.Protocol,string,string,string,string,int,string,bool,bool,bool,bool).displayName'></a>

`displayName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name shown to users\.

<a name='DiGi.Harness.Classes.ProviderConfiguration.ProviderConfiguration(string,string,DiGi.Harness.Enums.Protocol,string,string,string,string,int,string,bool,bool,bool,bool).protocol'></a>

`protocol` [Protocol](DiGi.Harness.Enums.md#DiGi.Harness.Enums.Protocol 'DiGi\.Harness\.Enums\.Protocol')

The wire protocol\.

<a name='DiGi.Harness.Classes.ProviderConfiguration.ProviderConfiguration(string,string,DiGi.Harness.Enums.Protocol,string,string,string,string,int,string,bool,bool,bool,bool).baseUri'></a>

`baseUri` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The base URI: for [Anthropic](DiGi.Harness.Enums.md#DiGi.Harness.Enums.Protocol.Anthropic 'DiGi\.Harness\.Enums\.Protocol\.Anthropic') without `/v1` \(`https://api.anthropic.com`\), for [OpenAI](DiGi.Harness.Enums.md#DiGi.Harness.Enums.Protocol.OpenAI 'DiGi\.Harness\.Enums\.Protocol\.OpenAI') including it \(`http://localhost:1234/v1`\)\.

<a name='DiGi.Harness.Classes.ProviderConfiguration.ProviderConfiguration(string,string,DiGi.Harness.Enums.Protocol,string,string,string,string,int,string,bool,bool,bool,bool).model'></a>

`model` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The model identifier sent to the provider\.

<a name='DiGi.Harness.Classes.ProviderConfiguration.ProviderConfiguration(string,string,DiGi.Harness.Enums.Protocol,string,string,string,string,int,string,bool,bool,bool,bool).key'></a>

`key` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The API key, or null for a local server that needs none\.

<a name='DiGi.Harness.Classes.ProviderConfiguration.ProviderConfiguration(string,string,DiGi.Harness.Enums.Protocol,string,string,string,string,int,string,bool,bool,bool,bool).keyEnvironmentVariable'></a>

`keyEnvironmentVariable` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The environment variable holding the API key, read when [key](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ProviderConfiguration.ProviderConfiguration(string,string,DiGi.Harness.Enums.Protocol,string,string,string,string,int,string,bool,bool,bool,bool).key 'DiGi\.Harness\.Classes\.ProviderConfiguration\.ProviderConfiguration\(string, string, DiGi\.Harness\.Enums\.Protocol, string, string, string, string, int, string, bool, bool, bool, bool\)\.key') is empty\.

<a name='DiGi.Harness.Classes.ProviderConfiguration.ProviderConfiguration(string,string,DiGi.Harness.Enums.Protocol,string,string,string,string,int,string,bool,bool,bool,bool).maxTokens'></a>

`maxTokens` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The maximum number of output tokens of one request; zero or less uses the default\.

<a name='DiGi.Harness.Classes.ProviderConfiguration.ProviderConfiguration(string,string,DiGi.Harness.Enums.Protocol,string,string,string,string,int,string,bool,bool,bool,bool).effort'></a>

`effort` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The effort level \(`low` to `max`\), sent as `output_config.effort` \(Anthropic\) or `reasoning_effort` \(OpenAI\); null sends nothing\.

<a name='DiGi.Harness.Classes.ProviderConfiguration.ProviderConfiguration(string,string,DiGi.Harness.Enums.Protocol,string,string,string,string,int,string,bool,bool,bool,bool).thinking'></a>

`thinking` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether summarized adaptive thinking is requested \(Anthropic protocol only\)\.

<a name='DiGi.Harness.Classes.ProviderConfiguration.ProviderConfiguration(string,string,DiGi.Harness.Enums.Protocol,string,string,string,string,int,string,bool,bool,bool,bool).replayReasoning'></a>

`replayReasoning` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether reasoning text is sent back as `reasoning_content` \(OpenAI protocol; DeepSeek thinking mode with tools needs it\)\.

<a name='DiGi.Harness.Classes.ProviderConfiguration.ProviderConfiguration(string,string,DiGi.Harness.Enums.Protocol,string,string,string,string,int,string,bool,bool,bool,bool).anthropicFallbacks'></a>

`anthropicFallbacks` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether server\-side refusal fallbacks are requested \(Anthropic first\-party API only; compatible endpoints reject the field\)\.

<a name='DiGi.Harness.Classes.ProviderConfiguration.ProviderConfiguration(string,string,DiGi.Harness.Enums.Protocol,string,string,string,string,int,string,bool,bool,bool,bool).enabled'></a>

`enabled` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether the provider can be selected\.

<a name='DiGi.Harness.Classes.ProviderConfiguration.ProviderConfiguration(System.Text.Json.Nodes.JsonObject)'></a>

## ProviderConfiguration\(JsonObject\) Constructor

Initializes a new instance of the [ProviderConfiguration](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ProviderConfiguration 'DiGi\.Harness\.Classes\.ProviderConfiguration') class from a JSON object\.

```csharp
public ProviderConfiguration(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Harness.Classes.ProviderConfiguration.ProviderConfiguration(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object to read from\.
### Properties

<a name='DiGi.Harness.Classes.ProviderConfiguration.AnthropicFallbacks'></a>

## ProviderConfiguration\.AnthropicFallbacks Property

Gets a value indicating whether server\-side refusal fallbacks are requested \(Anthropic first\-party API only\)\.

```csharp
public bool AnthropicFallbacks { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.Harness.Classes.ProviderConfiguration.BaseUri'></a>

## ProviderConfiguration\.BaseUri Property

Gets the base URI of the provider\.

```csharp
public string? BaseUri { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Classes.ProviderConfiguration.DisplayName'></a>

## ProviderConfiguration\.DisplayName Property

Gets the name shown to users\.

```csharp
public string? DisplayName { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Classes.ProviderConfiguration.Effort'></a>

## ProviderConfiguration\.Effort Property

Gets the effort level, or null to send none\.

```csharp
public string? Effort { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Classes.ProviderConfiguration.Enabled'></a>

## ProviderConfiguration\.Enabled Property

Gets a value indicating whether the provider can be selected\.

```csharp
public bool Enabled { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.Harness.Classes.ProviderConfiguration.Key'></a>

## ProviderConfiguration\.Key Property

Gets the API key; never log it or return it to a client\.

```csharp
public string? Key { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Classes.ProviderConfiguration.KeyEnvironmentVariable'></a>

## ProviderConfiguration\.KeyEnvironmentVariable Property

Gets the environment variable holding the API key, read when [Key](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ProviderConfiguration.Key 'DiGi\.Harness\.Classes\.ProviderConfiguration\.Key') is empty\.

```csharp
public string? KeyEnvironmentVariable { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Classes.ProviderConfiguration.MaxTokens'></a>

## ProviderConfiguration\.MaxTokens Property

Gets the maximum number of output tokens of one request; zero or less uses the default\.

```csharp
public int MaxTokens { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.Harness.Classes.ProviderConfiguration.Model'></a>

## ProviderConfiguration\.Model Property

Gets the model identifier sent to the provider\.

```csharp
public string? Model { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Classes.ProviderConfiguration.Name'></a>

## ProviderConfiguration\.Name Property

Gets the unique name clients select the provider by\.

```csharp
public string? Name { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Classes.ProviderConfiguration.Protocol'></a>

## ProviderConfiguration\.Protocol Property

Gets the wire protocol\.

```csharp
public DiGi.Harness.Enums.Protocol Protocol { get; }
```

#### Property Value
[Protocol](DiGi.Harness.Enums.md#DiGi.Harness.Enums.Protocol 'DiGi\.Harness\.Enums\.Protocol')

<a name='DiGi.Harness.Classes.ProviderConfiguration.ReplayReasoning'></a>

## ProviderConfiguration\.ReplayReasoning Property

Gets a value indicating whether reasoning text is sent back as `reasoning_content` \(OpenAI protocol\)\.

```csharp
public bool ReplayReasoning { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.Harness.Classes.ProviderConfiguration.Thinking'></a>

## ProviderConfiguration\.Thinking Property

Gets a value indicating whether summarized adaptive thinking is requested \(Anthropic protocol only\)\.

```csharp
public bool Thinking { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.Harness.Classes.RunOptions'></a>

## RunOptions Class

Options of one turn of the agent loop\.

```csharp
public class RunOptions : DiGi.Core.Classes.SerializableOptions, DiGi.Harness.Interfaces.IHarnessSerializableObject, DiGi.Harness.Interfaces.IHarnessObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.Core\.Classes\.SerializableOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableoptions 'DiGi\.Core\.Classes\.SerializableOptions') → RunOptions

Implements [IHarnessSerializableObject](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IHarnessSerializableObject 'DiGi\.Harness\.Interfaces\.IHarnessSerializableObject'), [IHarnessObject](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IHarnessObject 'DiGi\.Harness\.Interfaces\.IHarnessObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Harness.Classes.RunOptions.RunOptions()'></a>

## RunOptions\(\) Constructor

Initializes a new instance of the [RunOptions](DiGi.Harness.Classes.md#DiGi.Harness.Classes.RunOptions 'DiGi\.Harness\.Classes\.RunOptions') class with the default limits and no system prompt\.

```csharp
public RunOptions();
```

<a name='DiGi.Harness.Classes.RunOptions.RunOptions(DiGi.Harness.Classes.RunOptions)'></a>

## RunOptions\(RunOptions\) Constructor

Initializes a new instance of the [RunOptions](DiGi.Harness.Classes.md#DiGi.Harness.Classes.RunOptions 'DiGi\.Harness\.Classes\.RunOptions') class by copying another instance\.

```csharp
public RunOptions(DiGi.Harness.Classes.RunOptions? runOptions);
```
#### Parameters

<a name='DiGi.Harness.Classes.RunOptions.RunOptions(DiGi.Harness.Classes.RunOptions).runOptions'></a>

`runOptions` [RunOptions](DiGi.Harness.Classes.md#DiGi.Harness.Classes.RunOptions 'DiGi\.Harness\.Classes\.RunOptions')

The instance to copy from\.

<a name='DiGi.Harness.Classes.RunOptions.RunOptions(System.Text.Json.Nodes.JsonObject)'></a>

## RunOptions\(JsonObject\) Constructor

Initializes a new instance of the [RunOptions](DiGi.Harness.Classes.md#DiGi.Harness.Classes.RunOptions 'DiGi\.Harness\.Classes\.RunOptions') class from a JSON object\.

```csharp
public RunOptions(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Harness.Classes.RunOptions.RunOptions(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object to read from\.
### Properties

<a name='DiGi.Harness.Classes.RunOptions.MaxToolIterations'></a>

## RunOptions\.MaxToolIterations Property

Gets or sets the maximum number of model requests in the turn\.

```csharp
public int MaxToolIterations { get; set; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.Harness.Classes.RunOptions.MaxToolResultCharacters'></a>

## RunOptions\.MaxToolResultCharacters Property

Gets or sets the maximum number of characters of one tool result returned to the model\.

```csharp
public int MaxToolResultCharacters { get; set; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.Harness.Classes.RunOptions.SystemPrompt'></a>

## RunOptions\.SystemPrompt Property

Gets or sets the system prompt sent with every request of the turn\.

```csharp
public string? SystemPrompt { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Classes.ServerSentEvent'></a>

## ServerSentEvent Class

One event of a `text/event-stream`: its optional event name and its data \(multi\-line data joined with `\n`\)\.

```csharp
public class ServerSentEvent : DiGi.Harness.Interfaces.IHarnessObject, DiGi.Core.Interfaces.IObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ServerSentEvent

Implements [IHarnessObject](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IHarnessObject 'DiGi\.Harness\.Interfaces\.IHarnessObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject')
### Constructors

<a name='DiGi.Harness.Classes.ServerSentEvent.ServerSentEvent(string,string)'></a>

## ServerSentEvent\(string, string\) Constructor

Initializes a new instance of the [ServerSentEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ServerSentEvent 'DiGi\.Harness\.Classes\.ServerSentEvent') class\.

```csharp
public ServerSentEvent(string? name, string? data);
```
#### Parameters

<a name='DiGi.Harness.Classes.ServerSentEvent.ServerSentEvent(string,string).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The event name from the `event:` field, or null\.

<a name='DiGi.Harness.Classes.ServerSentEvent.ServerSentEvent(string,string).data'></a>

`data` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The data from the `data:` fields\.
### Properties

<a name='DiGi.Harness.Classes.ServerSentEvent.Data'></a>

## ServerSentEvent\.Data Property

Gets the data from the `data:` fields\.

```csharp
public string? Data { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Classes.ServerSentEvent.Name'></a>

## ServerSentEvent\.Name Property

Gets the event name from the `event:` field, or null\.

```csharp
public string? Name { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Classes.StepStartedEvent'></a>

## StepStartedEvent Class

A model request \(one step of the agent loop\) has started\.

```csharp
public class StepStartedEvent : DiGi.Harness.Classes.HarnessEvent
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [HarnessEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.HarnessEvent 'DiGi\.Harness\.Classes\.HarnessEvent') → StepStartedEvent
### Constructors

<a name='DiGi.Harness.Classes.StepStartedEvent.StepStartedEvent(DiGi.Harness.Classes.StepStartedEvent)'></a>

## StepStartedEvent\(StepStartedEvent\) Constructor

Initializes a new instance of the [StepStartedEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.StepStartedEvent 'DiGi\.Harness\.Classes\.StepStartedEvent') class by copying another instance\.

```csharp
public StepStartedEvent(DiGi.Harness.Classes.StepStartedEvent? stepStartedEvent);
```
#### Parameters

<a name='DiGi.Harness.Classes.StepStartedEvent.StepStartedEvent(DiGi.Harness.Classes.StepStartedEvent).stepStartedEvent'></a>

`stepStartedEvent` [StepStartedEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.StepStartedEvent 'DiGi\.Harness\.Classes\.StepStartedEvent')

The instance to copy from\.

<a name='DiGi.Harness.Classes.StepStartedEvent.StepStartedEvent(int,double)'></a>

## StepStartedEvent\(int, double\) Constructor

Initializes a new instance of the [StepStartedEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.StepStartedEvent 'DiGi\.Harness\.Classes\.StepStartedEvent') class\.

```csharp
public StepStartedEvent(int step, double elapsedMilliseconds);
```
#### Parameters

<a name='DiGi.Harness.Classes.StepStartedEvent.StepStartedEvent(int,double).step'></a>

`step` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The one\-based step number\.

<a name='DiGi.Harness.Classes.StepStartedEvent.StepStartedEvent(int,double).elapsedMilliseconds'></a>

`elapsedMilliseconds` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The time elapsed since the turn started, in milliseconds\.

<a name='DiGi.Harness.Classes.StepStartedEvent.StepStartedEvent(System.Text.Json.Nodes.JsonObject)'></a>

## StepStartedEvent\(JsonObject\) Constructor

Initializes a new instance of the [StepStartedEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.StepStartedEvent 'DiGi\.Harness\.Classes\.StepStartedEvent') class from a JSON object\.

```csharp
public StepStartedEvent(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Harness.Classes.StepStartedEvent.StepStartedEvent(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object to read from\.
### Properties

<a name='DiGi.Harness.Classes.StepStartedEvent.Step'></a>

## StepStartedEvent\.Step Property

Gets the one\-based step number\.

```csharp
public int Step { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.Harness.Classes.TextContent'></a>

## TextContent Class

A text block of a conversation message\.

```csharp
public class TextContent : DiGi.Core.Classes.SerializableObject, DiGi.Harness.Interfaces.IContent, DiGi.Harness.Interfaces.IHarnessSerializableObject, DiGi.Harness.Interfaces.IHarnessObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → TextContent

Implements [IContent](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IContent 'DiGi\.Harness\.Interfaces\.IContent'), [IHarnessSerializableObject](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IHarnessSerializableObject 'DiGi\.Harness\.Interfaces\.IHarnessSerializableObject'), [IHarnessObject](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IHarnessObject 'DiGi\.Harness\.Interfaces\.IHarnessObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Harness.Classes.TextContent.TextContent(DiGi.Harness.Classes.TextContent)'></a>

## TextContent\(TextContent\) Constructor

Initializes a new instance of the [TextContent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.TextContent 'DiGi\.Harness\.Classes\.TextContent') class by copying another instance\.

```csharp
public TextContent(DiGi.Harness.Classes.TextContent? textContent);
```
#### Parameters

<a name='DiGi.Harness.Classes.TextContent.TextContent(DiGi.Harness.Classes.TextContent).textContent'></a>

`textContent` [TextContent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.TextContent 'DiGi\.Harness\.Classes\.TextContent')

The instance to copy from\.

<a name='DiGi.Harness.Classes.TextContent.TextContent(string)'></a>

## TextContent\(string\) Constructor

Initializes a new instance of the [TextContent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.TextContent 'DiGi\.Harness\.Classes\.TextContent') class\.

```csharp
public TextContent(string? text);
```
#### Parameters

<a name='DiGi.Harness.Classes.TextContent.TextContent(string).text'></a>

`text` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The text\.

<a name='DiGi.Harness.Classes.TextContent.TextContent(System.Text.Json.Nodes.JsonObject)'></a>

## TextContent\(JsonObject\) Constructor

Initializes a new instance of the [TextContent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.TextContent 'DiGi\.Harness\.Classes\.TextContent') class from a JSON object\.

```csharp
public TextContent(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Harness.Classes.TextContent.TextContent(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object to read from\.
### Properties

<a name='DiGi.Harness.Classes.TextContent.Text'></a>

## TextContent\.Text Property

Gets the text\.

```csharp
public string? Text { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Classes.TextDeltaEvent'></a>

## TextDeltaEvent Class

A piece of the answer text has arrived\.

```csharp
public class TextDeltaEvent : DiGi.Harness.Classes.HarnessEvent
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [HarnessEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.HarnessEvent 'DiGi\.Harness\.Classes\.HarnessEvent') → TextDeltaEvent
### Constructors

<a name='DiGi.Harness.Classes.TextDeltaEvent.TextDeltaEvent(DiGi.Harness.Classes.TextDeltaEvent)'></a>

## TextDeltaEvent\(TextDeltaEvent\) Constructor

Initializes a new instance of the [TextDeltaEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.TextDeltaEvent 'DiGi\.Harness\.Classes\.TextDeltaEvent') class by copying another instance\.

```csharp
public TextDeltaEvent(DiGi.Harness.Classes.TextDeltaEvent? textDeltaEvent);
```
#### Parameters

<a name='DiGi.Harness.Classes.TextDeltaEvent.TextDeltaEvent(DiGi.Harness.Classes.TextDeltaEvent).textDeltaEvent'></a>

`textDeltaEvent` [TextDeltaEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.TextDeltaEvent 'DiGi\.Harness\.Classes\.TextDeltaEvent')

The instance to copy from\.

<a name='DiGi.Harness.Classes.TextDeltaEvent.TextDeltaEvent(string,double)'></a>

## TextDeltaEvent\(string, double\) Constructor

Initializes a new instance of the [TextDeltaEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.TextDeltaEvent 'DiGi\.Harness\.Classes\.TextDeltaEvent') class\.

```csharp
public TextDeltaEvent(string? text, double elapsedMilliseconds);
```
#### Parameters

<a name='DiGi.Harness.Classes.TextDeltaEvent.TextDeltaEvent(string,double).text'></a>

`text` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The text fragment\.

<a name='DiGi.Harness.Classes.TextDeltaEvent.TextDeltaEvent(string,double).elapsedMilliseconds'></a>

`elapsedMilliseconds` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The time elapsed since the turn started, in milliseconds\.

<a name='DiGi.Harness.Classes.TextDeltaEvent.TextDeltaEvent(System.Text.Json.Nodes.JsonObject)'></a>

## TextDeltaEvent\(JsonObject\) Constructor

Initializes a new instance of the [TextDeltaEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.TextDeltaEvent 'DiGi\.Harness\.Classes\.TextDeltaEvent') class from a JSON object\.

```csharp
public TextDeltaEvent(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Harness.Classes.TextDeltaEvent.TextDeltaEvent(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object to read from\.
### Properties

<a name='DiGi.Harness.Classes.TextDeltaEvent.Text'></a>

## TextDeltaEvent\.Text Property

Gets the text fragment\.

```csharp
public string? Text { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Classes.ThinkingCompletedEvent'></a>

## ThinkingCompletedEvent Class

A thinking block is complete; carries its whole text\.

The WebAPI layer turns it into a short summary line or drops it, depending on the client's thinking visibility.

```csharp
public class ThinkingCompletedEvent : DiGi.Harness.Classes.HarnessEvent
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [HarnessEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.HarnessEvent 'DiGi\.Harness\.Classes\.HarnessEvent') → ThinkingCompletedEvent
### Constructors

<a name='DiGi.Harness.Classes.ThinkingCompletedEvent.ThinkingCompletedEvent(DiGi.Harness.Classes.ThinkingCompletedEvent)'></a>

## ThinkingCompletedEvent\(ThinkingCompletedEvent\) Constructor

Initializes a new instance of the [ThinkingCompletedEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ThinkingCompletedEvent 'DiGi\.Harness\.Classes\.ThinkingCompletedEvent') class by copying another instance\.

```csharp
public ThinkingCompletedEvent(DiGi.Harness.Classes.ThinkingCompletedEvent? thinkingCompletedEvent);
```
#### Parameters

<a name='DiGi.Harness.Classes.ThinkingCompletedEvent.ThinkingCompletedEvent(DiGi.Harness.Classes.ThinkingCompletedEvent).thinkingCompletedEvent'></a>

`thinkingCompletedEvent` [ThinkingCompletedEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ThinkingCompletedEvent 'DiGi\.Harness\.Classes\.ThinkingCompletedEvent')

The instance to copy from\.

<a name='DiGi.Harness.Classes.ThinkingCompletedEvent.ThinkingCompletedEvent(string,double)'></a>

## ThinkingCompletedEvent\(string, double\) Constructor

Initializes a new instance of the [ThinkingCompletedEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ThinkingCompletedEvent 'DiGi\.Harness\.Classes\.ThinkingCompletedEvent') class\.

```csharp
public ThinkingCompletedEvent(string? text, double elapsedMilliseconds);
```
#### Parameters

<a name='DiGi.Harness.Classes.ThinkingCompletedEvent.ThinkingCompletedEvent(string,double).text'></a>

`text` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The whole thinking text of the block\.

<a name='DiGi.Harness.Classes.ThinkingCompletedEvent.ThinkingCompletedEvent(string,double).elapsedMilliseconds'></a>

`elapsedMilliseconds` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The time elapsed since the turn started, in milliseconds\.

<a name='DiGi.Harness.Classes.ThinkingCompletedEvent.ThinkingCompletedEvent(System.Text.Json.Nodes.JsonObject)'></a>

## ThinkingCompletedEvent\(JsonObject\) Constructor

Initializes a new instance of the [ThinkingCompletedEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ThinkingCompletedEvent 'DiGi\.Harness\.Classes\.ThinkingCompletedEvent') class from a JSON object\.

```csharp
public ThinkingCompletedEvent(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Harness.Classes.ThinkingCompletedEvent.ThinkingCompletedEvent(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object to read from\.
### Properties

<a name='DiGi.Harness.Classes.ThinkingCompletedEvent.Text'></a>

## ThinkingCompletedEvent\.Text Property

Gets the whole thinking text of the block\.

```csharp
public string? Text { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Classes.ThinkingContent'></a>

## ThinkingContent Class

A thinking block of an assistant message\.

Anthropic thinking blocks are replayed to the same provider unchanged: [Signature](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ThinkingContent.Signature 'DiGi\.Harness\.Classes\.ThinkingContent\.Signature') for a `thinking` block and [RedactedData](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ThinkingContent.RedactedData 'DiGi\.Harness\.Classes\.ThinkingContent\.RedactedData') for a `redacted_thinking` block. OpenAI-protocol reasoning (`reasoning_content`) has neither.

```csharp
public class ThinkingContent : DiGi.Core.Classes.SerializableObject, DiGi.Harness.Interfaces.IContent, DiGi.Harness.Interfaces.IHarnessSerializableObject, DiGi.Harness.Interfaces.IHarnessObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → ThinkingContent

Implements [IContent](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IContent 'DiGi\.Harness\.Interfaces\.IContent'), [IHarnessSerializableObject](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IHarnessSerializableObject 'DiGi\.Harness\.Interfaces\.IHarnessSerializableObject'), [IHarnessObject](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IHarnessObject 'DiGi\.Harness\.Interfaces\.IHarnessObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Harness.Classes.ThinkingContent.ThinkingContent(DiGi.Harness.Classes.ThinkingContent)'></a>

## ThinkingContent\(ThinkingContent\) Constructor

Initializes a new instance of the [ThinkingContent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ThinkingContent 'DiGi\.Harness\.Classes\.ThinkingContent') class by copying another instance\.

```csharp
public ThinkingContent(DiGi.Harness.Classes.ThinkingContent? thinkingContent);
```
#### Parameters

<a name='DiGi.Harness.Classes.ThinkingContent.ThinkingContent(DiGi.Harness.Classes.ThinkingContent).thinkingContent'></a>

`thinkingContent` [ThinkingContent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ThinkingContent 'DiGi\.Harness\.Classes\.ThinkingContent')

The instance to copy from\.

<a name='DiGi.Harness.Classes.ThinkingContent.ThinkingContent(string,string,string)'></a>

## ThinkingContent\(string, string, string\) Constructor

Initializes a new instance of the [ThinkingContent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ThinkingContent 'DiGi\.Harness\.Classes\.ThinkingContent') class\.

```csharp
public ThinkingContent(string? text, string? signature, string? redactedData);
```
#### Parameters

<a name='DiGi.Harness.Classes.ThinkingContent.ThinkingContent(string,string,string).text'></a>

`text` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The thinking text \(a summary on current Anthropic models; may be empty\)\.

<a name='DiGi.Harness.Classes.ThinkingContent.ThinkingContent(string,string,string).signature'></a>

`signature` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The Anthropic signature of the block\.

<a name='DiGi.Harness.Classes.ThinkingContent.ThinkingContent(string,string,string).redactedData'></a>

`redactedData` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The opaque data of an Anthropic `redacted_thinking` block\.

<a name='DiGi.Harness.Classes.ThinkingContent.ThinkingContent(System.Text.Json.Nodes.JsonObject)'></a>

## ThinkingContent\(JsonObject\) Constructor

Initializes a new instance of the [ThinkingContent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ThinkingContent 'DiGi\.Harness\.Classes\.ThinkingContent') class from a JSON object\.

```csharp
public ThinkingContent(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Harness.Classes.ThinkingContent.ThinkingContent(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object to read from\.
### Properties

<a name='DiGi.Harness.Classes.ThinkingContent.RedactedData'></a>

## ThinkingContent\.RedactedData Property

Gets the opaque data of an Anthropic `redacted_thinking` block\.

```csharp
public string? RedactedData { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Classes.ThinkingContent.Signature'></a>

## ThinkingContent\.Signature Property

Gets the Anthropic signature of the block\.

```csharp
public string? Signature { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Classes.ThinkingContent.Text'></a>

## ThinkingContent\.Text Property

Gets the thinking text\.

```csharp
public string? Text { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Classes.ThinkingDeltaEvent'></a>

## ThinkingDeltaEvent Class

A piece of thinking text has arrived \(sent to clients only with full thinking visibility\)\.

```csharp
public class ThinkingDeltaEvent : DiGi.Harness.Classes.HarnessEvent
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [HarnessEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.HarnessEvent 'DiGi\.Harness\.Classes\.HarnessEvent') → ThinkingDeltaEvent
### Constructors

<a name='DiGi.Harness.Classes.ThinkingDeltaEvent.ThinkingDeltaEvent(DiGi.Harness.Classes.ThinkingDeltaEvent)'></a>

## ThinkingDeltaEvent\(ThinkingDeltaEvent\) Constructor

Initializes a new instance of the [ThinkingDeltaEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ThinkingDeltaEvent 'DiGi\.Harness\.Classes\.ThinkingDeltaEvent') class by copying another instance\.

```csharp
public ThinkingDeltaEvent(DiGi.Harness.Classes.ThinkingDeltaEvent? thinkingDeltaEvent);
```
#### Parameters

<a name='DiGi.Harness.Classes.ThinkingDeltaEvent.ThinkingDeltaEvent(DiGi.Harness.Classes.ThinkingDeltaEvent).thinkingDeltaEvent'></a>

`thinkingDeltaEvent` [ThinkingDeltaEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ThinkingDeltaEvent 'DiGi\.Harness\.Classes\.ThinkingDeltaEvent')

The instance to copy from\.

<a name='DiGi.Harness.Classes.ThinkingDeltaEvent.ThinkingDeltaEvent(string,double)'></a>

## ThinkingDeltaEvent\(string, double\) Constructor

Initializes a new instance of the [ThinkingDeltaEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ThinkingDeltaEvent 'DiGi\.Harness\.Classes\.ThinkingDeltaEvent') class\.

```csharp
public ThinkingDeltaEvent(string? text, double elapsedMilliseconds);
```
#### Parameters

<a name='DiGi.Harness.Classes.ThinkingDeltaEvent.ThinkingDeltaEvent(string,double).text'></a>

`text` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The thinking fragment\.

<a name='DiGi.Harness.Classes.ThinkingDeltaEvent.ThinkingDeltaEvent(string,double).elapsedMilliseconds'></a>

`elapsedMilliseconds` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The time elapsed since the turn started, in milliseconds\.

<a name='DiGi.Harness.Classes.ThinkingDeltaEvent.ThinkingDeltaEvent(System.Text.Json.Nodes.JsonObject)'></a>

## ThinkingDeltaEvent\(JsonObject\) Constructor

Initializes a new instance of the [ThinkingDeltaEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ThinkingDeltaEvent 'DiGi\.Harness\.Classes\.ThinkingDeltaEvent') class from a JSON object\.

```csharp
public ThinkingDeltaEvent(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Harness.Classes.ThinkingDeltaEvent.ThinkingDeltaEvent(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object to read from\.
### Properties

<a name='DiGi.Harness.Classes.ThinkingDeltaEvent.Text'></a>

## ThinkingDeltaEvent\.Text Property

Gets the thinking fragment\.

```csharp
public string? Text { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Classes.ThinkingSummaryEvent'></a>

## ThinkingSummaryEvent Class

A short summary line of one completed thinking block \(sent to clients with summary thinking visibility\)\.

```csharp
public class ThinkingSummaryEvent : DiGi.Harness.Classes.HarnessEvent
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [HarnessEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.HarnessEvent 'DiGi\.Harness\.Classes\.HarnessEvent') → ThinkingSummaryEvent
### Constructors

<a name='DiGi.Harness.Classes.ThinkingSummaryEvent.ThinkingSummaryEvent(DiGi.Harness.Classes.ThinkingSummaryEvent)'></a>

## ThinkingSummaryEvent\(ThinkingSummaryEvent\) Constructor

Initializes a new instance of the [ThinkingSummaryEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ThinkingSummaryEvent 'DiGi\.Harness\.Classes\.ThinkingSummaryEvent') class by copying another instance\.

```csharp
public ThinkingSummaryEvent(DiGi.Harness.Classes.ThinkingSummaryEvent? thinkingSummaryEvent);
```
#### Parameters

<a name='DiGi.Harness.Classes.ThinkingSummaryEvent.ThinkingSummaryEvent(DiGi.Harness.Classes.ThinkingSummaryEvent).thinkingSummaryEvent'></a>

`thinkingSummaryEvent` [ThinkingSummaryEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ThinkingSummaryEvent 'DiGi\.Harness\.Classes\.ThinkingSummaryEvent')

The instance to copy from\.

<a name='DiGi.Harness.Classes.ThinkingSummaryEvent.ThinkingSummaryEvent(string,double)'></a>

## ThinkingSummaryEvent\(string, double\) Constructor

Initializes a new instance of the [ThinkingSummaryEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ThinkingSummaryEvent 'DiGi\.Harness\.Classes\.ThinkingSummaryEvent') class\.

```csharp
public ThinkingSummaryEvent(string? text, double elapsedMilliseconds);
```
#### Parameters

<a name='DiGi.Harness.Classes.ThinkingSummaryEvent.ThinkingSummaryEvent(string,double).text'></a>

`text` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The summary line\.

<a name='DiGi.Harness.Classes.ThinkingSummaryEvent.ThinkingSummaryEvent(string,double).elapsedMilliseconds'></a>

`elapsedMilliseconds` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The time elapsed since the turn started, in milliseconds\.

<a name='DiGi.Harness.Classes.ThinkingSummaryEvent.ThinkingSummaryEvent(System.Text.Json.Nodes.JsonObject)'></a>

## ThinkingSummaryEvent\(JsonObject\) Constructor

Initializes a new instance of the [ThinkingSummaryEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ThinkingSummaryEvent 'DiGi\.Harness\.Classes\.ThinkingSummaryEvent') class from a JSON object\.

```csharp
public ThinkingSummaryEvent(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Harness.Classes.ThinkingSummaryEvent.ThinkingSummaryEvent(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object to read from\.
### Properties

<a name='DiGi.Harness.Classes.ThinkingSummaryEvent.Text'></a>

## ThinkingSummaryEvent\.Text Property

Gets the summary line\.

```csharp
public string? Text { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Classes.ToolCallCompletedEvent'></a>

## ToolCallCompletedEvent Class

A tool call has finished\.

```csharp
public class ToolCallCompletedEvent : DiGi.Harness.Classes.HarnessEvent
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [HarnessEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.HarnessEvent 'DiGi\.Harness\.Classes\.HarnessEvent') → ToolCallCompletedEvent
### Constructors

<a name='DiGi.Harness.Classes.ToolCallCompletedEvent.ToolCallCompletedEvent(DiGi.Harness.Classes.ToolCallCompletedEvent)'></a>

## ToolCallCompletedEvent\(ToolCallCompletedEvent\) Constructor

Initializes a new instance of the [ToolCallCompletedEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolCallCompletedEvent 'DiGi\.Harness\.Classes\.ToolCallCompletedEvent') class by copying another instance\.

```csharp
public ToolCallCompletedEvent(DiGi.Harness.Classes.ToolCallCompletedEvent? toolCallCompletedEvent);
```
#### Parameters

<a name='DiGi.Harness.Classes.ToolCallCompletedEvent.ToolCallCompletedEvent(DiGi.Harness.Classes.ToolCallCompletedEvent).toolCallCompletedEvent'></a>

`toolCallCompletedEvent` [ToolCallCompletedEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolCallCompletedEvent 'DiGi\.Harness\.Classes\.ToolCallCompletedEvent')

The instance to copy from\.

<a name='DiGi.Harness.Classes.ToolCallCompletedEvent.ToolCallCompletedEvent(string,string,bool,double,int,bool,double)'></a>

## ToolCallCompletedEvent\(string, string, bool, double, int, bool, double\) Constructor

Initializes a new instance of the [ToolCallCompletedEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolCallCompletedEvent 'DiGi\.Harness\.Classes\.ToolCallCompletedEvent') class\.

```csharp
public ToolCallCompletedEvent(string? toolUseId, string? toolName, bool isError, double durationMilliseconds, int characters, bool truncated, double elapsedMilliseconds);
```
#### Parameters

<a name='DiGi.Harness.Classes.ToolCallCompletedEvent.ToolCallCompletedEvent(string,string,bool,double,int,bool,double).toolUseId'></a>

`toolUseId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The call identifier\.

<a name='DiGi.Harness.Classes.ToolCallCompletedEvent.ToolCallCompletedEvent(string,string,bool,double,int,bool,double).toolName'></a>

`toolName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the tool\.

<a name='DiGi.Harness.Classes.ToolCallCompletedEvent.ToolCallCompletedEvent(string,string,bool,double,int,bool,double).isError'></a>

`isError` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether the call failed\.

<a name='DiGi.Harness.Classes.ToolCallCompletedEvent.ToolCallCompletedEvent(string,string,bool,double,int,bool,double).durationMilliseconds'></a>

`durationMilliseconds` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The duration of the call in milliseconds\.

<a name='DiGi.Harness.Classes.ToolCallCompletedEvent.ToolCallCompletedEvent(string,string,bool,double,int,bool,double).characters'></a>

`characters` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The length of the full result text, before truncation\.

<a name='DiGi.Harness.Classes.ToolCallCompletedEvent.ToolCallCompletedEvent(string,string,bool,double,int,bool,double).truncated'></a>

`truncated` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether the result was truncated before it was returned to the model\.

<a name='DiGi.Harness.Classes.ToolCallCompletedEvent.ToolCallCompletedEvent(string,string,bool,double,int,bool,double).elapsedMilliseconds'></a>

`elapsedMilliseconds` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The time elapsed since the turn started, in milliseconds\.

<a name='DiGi.Harness.Classes.ToolCallCompletedEvent.ToolCallCompletedEvent(System.Text.Json.Nodes.JsonObject)'></a>

## ToolCallCompletedEvent\(JsonObject\) Constructor

Initializes a new instance of the [ToolCallCompletedEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolCallCompletedEvent 'DiGi\.Harness\.Classes\.ToolCallCompletedEvent') class from a JSON object\.

```csharp
public ToolCallCompletedEvent(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Harness.Classes.ToolCallCompletedEvent.ToolCallCompletedEvent(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object to read from\.
### Properties

<a name='DiGi.Harness.Classes.ToolCallCompletedEvent.Characters'></a>

## ToolCallCompletedEvent\.Characters Property

Gets the length of the full result text, before truncation\.

```csharp
public int Characters { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.Harness.Classes.ToolCallCompletedEvent.DurationMilliseconds'></a>

## ToolCallCompletedEvent\.DurationMilliseconds Property

Gets the duration of the call in milliseconds\.

```csharp
public double DurationMilliseconds { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Harness.Classes.ToolCallCompletedEvent.IsError'></a>

## ToolCallCompletedEvent\.IsError Property

Gets a value indicating whether the call failed\.

```csharp
public bool IsError { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.Harness.Classes.ToolCallCompletedEvent.ToolName'></a>

## ToolCallCompletedEvent\.ToolName Property

Gets the name of the tool\.

```csharp
public string? ToolName { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Classes.ToolCallCompletedEvent.ToolUseId'></a>

## ToolCallCompletedEvent\.ToolUseId Property

Gets the call identifier\.

```csharp
public string? ToolUseId { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Classes.ToolCallCompletedEvent.Truncated'></a>

## ToolCallCompletedEvent\.Truncated Property

Gets a value indicating whether the result was truncated before it was returned to the model\.

```csharp
public bool Truncated { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.Harness.Classes.ToolCallStartedEvent'></a>

## ToolCallStartedEvent Class

A tool call has started\.

```csharp
public class ToolCallStartedEvent : DiGi.Harness.Classes.HarnessEvent
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [HarnessEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.HarnessEvent 'DiGi\.Harness\.Classes\.HarnessEvent') → ToolCallStartedEvent
### Constructors

<a name='DiGi.Harness.Classes.ToolCallStartedEvent.ToolCallStartedEvent(DiGi.Harness.Classes.ToolCallStartedEvent)'></a>

## ToolCallStartedEvent\(ToolCallStartedEvent\) Constructor

Initializes a new instance of the [ToolCallStartedEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolCallStartedEvent 'DiGi\.Harness\.Classes\.ToolCallStartedEvent') class by copying another instance\.

```csharp
public ToolCallStartedEvent(DiGi.Harness.Classes.ToolCallStartedEvent? toolCallStartedEvent);
```
#### Parameters

<a name='DiGi.Harness.Classes.ToolCallStartedEvent.ToolCallStartedEvent(DiGi.Harness.Classes.ToolCallStartedEvent).toolCallStartedEvent'></a>

`toolCallStartedEvent` [ToolCallStartedEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolCallStartedEvent 'DiGi\.Harness\.Classes\.ToolCallStartedEvent')

The instance to copy from\.

<a name='DiGi.Harness.Classes.ToolCallStartedEvent.ToolCallStartedEvent(string,string,string,double)'></a>

## ToolCallStartedEvent\(string, string, string, double\) Constructor

Initializes a new instance of the [ToolCallStartedEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolCallStartedEvent 'DiGi\.Harness\.Classes\.ToolCallStartedEvent') class\.

```csharp
public ToolCallStartedEvent(string? toolUseId, string? toolName, string? inputJson, double elapsedMilliseconds);
```
#### Parameters

<a name='DiGi.Harness.Classes.ToolCallStartedEvent.ToolCallStartedEvent(string,string,string,double).toolUseId'></a>

`toolUseId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The call identifier\.

<a name='DiGi.Harness.Classes.ToolCallStartedEvent.ToolCallStartedEvent(string,string,string,double).toolName'></a>

`toolName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the tool\.

<a name='DiGi.Harness.Classes.ToolCallStartedEvent.ToolCallStartedEvent(string,string,string,double).inputJson'></a>

`inputJson` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The input as JSON text\.

<a name='DiGi.Harness.Classes.ToolCallStartedEvent.ToolCallStartedEvent(string,string,string,double).elapsedMilliseconds'></a>

`elapsedMilliseconds` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The time elapsed since the turn started, in milliseconds\.

<a name='DiGi.Harness.Classes.ToolCallStartedEvent.ToolCallStartedEvent(System.Text.Json.Nodes.JsonObject)'></a>

## ToolCallStartedEvent\(JsonObject\) Constructor

Initializes a new instance of the [ToolCallStartedEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolCallStartedEvent 'DiGi\.Harness\.Classes\.ToolCallStartedEvent') class from a JSON object\.

```csharp
public ToolCallStartedEvent(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Harness.Classes.ToolCallStartedEvent.ToolCallStartedEvent(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object to read from\.
### Properties

<a name='DiGi.Harness.Classes.ToolCallStartedEvent.InputJson'></a>

## ToolCallStartedEvent\.InputJson Property

Gets the input as JSON text\.

```csharp
public string? InputJson { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Classes.ToolCallStartedEvent.ToolName'></a>

## ToolCallStartedEvent\.ToolName Property

Gets the name of the tool\.

```csharp
public string? ToolName { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Classes.ToolCallStartedEvent.ToolUseId'></a>

## ToolCallStartedEvent\.ToolUseId Property

Gets the call identifier\.

```csharp
public string? ToolUseId { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Classes.ToolDefinition'></a>

## ToolDefinition Class

The definition of a tool sent to the model: its name, description and JSON input schema\.

The schema travels as JSON text ([InputSchemaJson](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolDefinition.InputSchemaJson 'DiGi\.Harness\.Classes\.ToolDefinition\.InputSchemaJson')); read it parsed with [InputSchema\(this ToolDefinition\)](DiGi.Harness.md#DiGi.Harness.Query.InputSchema(thisDiGi.Harness.Classes.ToolDefinition) 'DiGi\.Harness\.Query\.InputSchema\(this DiGi\.Harness\.Classes\.ToolDefinition\)').

```csharp
public class ToolDefinition : DiGi.Core.Classes.SerializableObject, DiGi.Harness.Interfaces.IHarnessSerializableObject, DiGi.Harness.Interfaces.IHarnessObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → ToolDefinition

Implements [IHarnessSerializableObject](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IHarnessSerializableObject 'DiGi\.Harness\.Interfaces\.IHarnessSerializableObject'), [IHarnessObject](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IHarnessObject 'DiGi\.Harness\.Interfaces\.IHarnessObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Harness.Classes.ToolDefinition.ToolDefinition(DiGi.Harness.Classes.ToolDefinition)'></a>

## ToolDefinition\(ToolDefinition\) Constructor

Initializes a new instance of the [ToolDefinition](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolDefinition 'DiGi\.Harness\.Classes\.ToolDefinition') class by copying another instance\.

```csharp
public ToolDefinition(DiGi.Harness.Classes.ToolDefinition? toolDefinition);
```
#### Parameters

<a name='DiGi.Harness.Classes.ToolDefinition.ToolDefinition(DiGi.Harness.Classes.ToolDefinition).toolDefinition'></a>

`toolDefinition` [ToolDefinition](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolDefinition 'DiGi\.Harness\.Classes\.ToolDefinition')

The instance to copy from\.

<a name='DiGi.Harness.Classes.ToolDefinition.ToolDefinition(string,string,string)'></a>

## ToolDefinition\(string, string, string\) Constructor

Initializes a new instance of the [ToolDefinition](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolDefinition 'DiGi\.Harness\.Classes\.ToolDefinition') class\.

```csharp
public ToolDefinition(string? name, string? description, string? inputSchemaJson);
```
#### Parameters

<a name='DiGi.Harness.Classes.ToolDefinition.ToolDefinition(string,string,string).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The tool name \(letters, digits, `_` and `-`\)\.

<a name='DiGi.Harness.Classes.ToolDefinition.ToolDefinition(string,string,string).description'></a>

`description` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

What the tool does and when to use it\.

<a name='DiGi.Harness.Classes.ToolDefinition.ToolDefinition(string,string,string).inputSchemaJson'></a>

`inputSchemaJson` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The JSON schema of the input, as JSON text\.

<a name='DiGi.Harness.Classes.ToolDefinition.ToolDefinition(System.Text.Json.Nodes.JsonObject)'></a>

## ToolDefinition\(JsonObject\) Constructor

Initializes a new instance of the [ToolDefinition](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolDefinition 'DiGi\.Harness\.Classes\.ToolDefinition') class from a JSON object\.

```csharp
public ToolDefinition(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Harness.Classes.ToolDefinition.ToolDefinition(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object to read from\.
### Properties

<a name='DiGi.Harness.Classes.ToolDefinition.Description'></a>

## ToolDefinition\.Description Property

Gets what the tool does and when to use it\.

```csharp
public string? Description { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Classes.ToolDefinition.InputSchemaJson'></a>

## ToolDefinition\.InputSchemaJson Property

Gets the JSON schema of the input, as JSON text\.

```csharp
public string? InputSchemaJson { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Classes.ToolDefinition.Name'></a>

## ToolDefinition\.Name Property

Gets the tool name\.

```csharp
public string? Name { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Classes.ToolResultContent'></a>

## ToolResultContent Class

The result of one tool call, returned to the model\.

```csharp
public class ToolResultContent : DiGi.Core.Classes.SerializableObject, DiGi.Harness.Interfaces.IContent, DiGi.Harness.Interfaces.IHarnessSerializableObject, DiGi.Harness.Interfaces.IHarnessObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → ToolResultContent

Implements [IContent](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IContent 'DiGi\.Harness\.Interfaces\.IContent'), [IHarnessSerializableObject](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IHarnessSerializableObject 'DiGi\.Harness\.Interfaces\.IHarnessSerializableObject'), [IHarnessObject](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IHarnessObject 'DiGi\.Harness\.Interfaces\.IHarnessObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Harness.Classes.ToolResultContent.ToolResultContent(DiGi.Harness.Classes.ToolResultContent)'></a>

## ToolResultContent\(ToolResultContent\) Constructor

Initializes a new instance of the [ToolResultContent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolResultContent 'DiGi\.Harness\.Classes\.ToolResultContent') class by copying another instance\.

```csharp
public ToolResultContent(DiGi.Harness.Classes.ToolResultContent? toolResultContent);
```
#### Parameters

<a name='DiGi.Harness.Classes.ToolResultContent.ToolResultContent(DiGi.Harness.Classes.ToolResultContent).toolResultContent'></a>

`toolResultContent` [ToolResultContent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolResultContent 'DiGi\.Harness\.Classes\.ToolResultContent')

The instance to copy from\.

<a name='DiGi.Harness.Classes.ToolResultContent.ToolResultContent(string,string,bool)'></a>

## ToolResultContent\(string, string, bool\) Constructor

Initializes a new instance of the [ToolResultContent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolResultContent 'DiGi\.Harness\.Classes\.ToolResultContent') class\.

```csharp
public ToolResultContent(string? toolUseId, string? text, bool isError);
```
#### Parameters

<a name='DiGi.Harness.Classes.ToolResultContent.ToolResultContent(string,string,bool).toolUseId'></a>

`toolUseId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The identifier of the call this result answers\.

<a name='DiGi.Harness.Classes.ToolResultContent.ToolResultContent(string,string,bool).text'></a>

`text` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The result text\.

<a name='DiGi.Harness.Classes.ToolResultContent.ToolResultContent(string,string,bool).isError'></a>

`isError` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether the call failed\.

<a name='DiGi.Harness.Classes.ToolResultContent.ToolResultContent(System.Text.Json.Nodes.JsonObject)'></a>

## ToolResultContent\(JsonObject\) Constructor

Initializes a new instance of the [ToolResultContent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolResultContent 'DiGi\.Harness\.Classes\.ToolResultContent') class from a JSON object\.

```csharp
public ToolResultContent(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Harness.Classes.ToolResultContent.ToolResultContent(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object to read from\.
### Properties

<a name='DiGi.Harness.Classes.ToolResultContent.IsError'></a>

## ToolResultContent\.IsError Property

Gets a value indicating whether the call failed\.

```csharp
public bool IsError { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.Harness.Classes.ToolResultContent.Text'></a>

## ToolResultContent\.Text Property

Gets the result text\.

```csharp
public string? Text { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Classes.ToolResultContent.ToolUseId'></a>

## ToolResultContent\.ToolUseId Property

Gets the identifier of the call this result answers\.

```csharp
public string? ToolUseId { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Classes.ToolUseContent'></a>

## ToolUseContent Class

A tool call made by the model\.

The input travels as JSON text ([InputJson](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolUseContent.InputJson 'DiGi\.Harness\.Classes\.ToolUseContent\.InputJson')): a [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject') member does not survive the DiGi serializer. Read it parsed with [Input\(this ToolUseContent\)](DiGi.Harness.md#DiGi.Harness.Query.Input(thisDiGi.Harness.Classes.ToolUseContent) 'DiGi\.Harness\.Query\.Input\(this DiGi\.Harness\.Classes\.ToolUseContent\)').

```csharp
public class ToolUseContent : DiGi.Core.Classes.SerializableObject, DiGi.Harness.Interfaces.IContent, DiGi.Harness.Interfaces.IHarnessSerializableObject, DiGi.Harness.Interfaces.IHarnessObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → ToolUseContent

Implements [IContent](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IContent 'DiGi\.Harness\.Interfaces\.IContent'), [IHarnessSerializableObject](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IHarnessSerializableObject 'DiGi\.Harness\.Interfaces\.IHarnessSerializableObject'), [IHarnessObject](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IHarnessObject 'DiGi\.Harness\.Interfaces\.IHarnessObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Harness.Classes.ToolUseContent.ToolUseContent(DiGi.Harness.Classes.ToolUseContent)'></a>

## ToolUseContent\(ToolUseContent\) Constructor

Initializes a new instance of the [ToolUseContent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolUseContent 'DiGi\.Harness\.Classes\.ToolUseContent') class by copying another instance\.

```csharp
public ToolUseContent(DiGi.Harness.Classes.ToolUseContent? toolUseContent);
```
#### Parameters

<a name='DiGi.Harness.Classes.ToolUseContent.ToolUseContent(DiGi.Harness.Classes.ToolUseContent).toolUseContent'></a>

`toolUseContent` [ToolUseContent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolUseContent 'DiGi\.Harness\.Classes\.ToolUseContent')

The instance to copy from\.

<a name='DiGi.Harness.Classes.ToolUseContent.ToolUseContent(string,string,string)'></a>

## ToolUseContent\(string, string, string\) Constructor

Initializes a new instance of the [ToolUseContent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolUseContent 'DiGi\.Harness\.Classes\.ToolUseContent') class\.

```csharp
public ToolUseContent(string? id, string? name, string? inputJson);
```
#### Parameters

<a name='DiGi.Harness.Classes.ToolUseContent.ToolUseContent(string,string,string).id'></a>

`id` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The call identifier assigned by the provider\.

<a name='DiGi.Harness.Classes.ToolUseContent.ToolUseContent(string,string,string).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the tool\.

<a name='DiGi.Harness.Classes.ToolUseContent.ToolUseContent(string,string,string).inputJson'></a>

`inputJson` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The input as JSON text, exactly as the model produced it\.

<a name='DiGi.Harness.Classes.ToolUseContent.ToolUseContent(System.Text.Json.Nodes.JsonObject)'></a>

## ToolUseContent\(JsonObject\) Constructor

Initializes a new instance of the [ToolUseContent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolUseContent 'DiGi\.Harness\.Classes\.ToolUseContent') class from a JSON object\.

```csharp
public ToolUseContent(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Harness.Classes.ToolUseContent.ToolUseContent(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object to read from\.
### Properties

<a name='DiGi.Harness.Classes.ToolUseContent.Id'></a>

## ToolUseContent\.Id Property

Gets the call identifier assigned by the provider\.

```csharp
public string? Id { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Classes.ToolUseContent.InputJson'></a>

## ToolUseContent\.InputJson Property

Gets the input as JSON text, exactly as the model produced it \(may be invalid or truncated\)\.

```csharp
public string? InputJson { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Classes.ToolUseContent.Name'></a>

## ToolUseContent\.Name Property

Gets the name of the tool\.

```csharp
public string? Name { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Classes.TurnCompletedEvent'></a>

## TurnCompletedEvent Class

The turn has ended, normally or not; always the last event of a turn\.

```csharp
public class TurnCompletedEvent : DiGi.Harness.Classes.HarnessEvent
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [HarnessEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.HarnessEvent 'DiGi\.Harness\.Classes\.HarnessEvent') → TurnCompletedEvent
### Constructors

<a name='DiGi.Harness.Classes.TurnCompletedEvent.TurnCompletedEvent(DiGi.Harness.Classes.TurnCompletedEvent)'></a>

## TurnCompletedEvent\(TurnCompletedEvent\) Constructor

Initializes a new instance of the [TurnCompletedEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.TurnCompletedEvent 'DiGi\.Harness\.Classes\.TurnCompletedEvent') class by copying another instance\.

```csharp
public TurnCompletedEvent(DiGi.Harness.Classes.TurnCompletedEvent? turnCompletedEvent);
```
#### Parameters

<a name='DiGi.Harness.Classes.TurnCompletedEvent.TurnCompletedEvent(DiGi.Harness.Classes.TurnCompletedEvent).turnCompletedEvent'></a>

`turnCompletedEvent` [TurnCompletedEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.TurnCompletedEvent 'DiGi\.Harness\.Classes\.TurnCompletedEvent')

The instance to copy from\.

<a name='DiGi.Harness.Classes.TurnCompletedEvent.TurnCompletedEvent(DiGi.Harness.Classes.TurnResult,double)'></a>

## TurnCompletedEvent\(TurnResult, double\) Constructor

Initializes a new instance of the [TurnCompletedEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.TurnCompletedEvent 'DiGi\.Harness\.Classes\.TurnCompletedEvent') class\.

```csharp
public TurnCompletedEvent(DiGi.Harness.Classes.TurnResult? turnResult, double elapsedMilliseconds);
```
#### Parameters

<a name='DiGi.Harness.Classes.TurnCompletedEvent.TurnCompletedEvent(DiGi.Harness.Classes.TurnResult,double).turnResult'></a>

`turnResult` [TurnResult](DiGi.Harness.Classes.md#DiGi.Harness.Classes.TurnResult 'DiGi\.Harness\.Classes\.TurnResult')

The outcome of the turn\.

<a name='DiGi.Harness.Classes.TurnCompletedEvent.TurnCompletedEvent(DiGi.Harness.Classes.TurnResult,double).elapsedMilliseconds'></a>

`elapsedMilliseconds` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The time elapsed since the turn started, in milliseconds\.

<a name='DiGi.Harness.Classes.TurnCompletedEvent.TurnCompletedEvent(System.Text.Json.Nodes.JsonObject)'></a>

## TurnCompletedEvent\(JsonObject\) Constructor

Initializes a new instance of the [TurnCompletedEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.TurnCompletedEvent 'DiGi\.Harness\.Classes\.TurnCompletedEvent') class from a JSON object\.

```csharp
public TurnCompletedEvent(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Harness.Classes.TurnCompletedEvent.TurnCompletedEvent(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object to read from\.
### Properties

<a name='DiGi.Harness.Classes.TurnCompletedEvent.TurnResult'></a>

## TurnCompletedEvent\.TurnResult Property

Gets the outcome of the turn\.

```csharp
public DiGi.Harness.Classes.TurnResult? TurnResult { get; }
```

#### Property Value
[TurnResult](DiGi.Harness.Classes.md#DiGi.Harness.Classes.TurnResult 'DiGi\.Harness\.Classes\.TurnResult')

<a name='DiGi.Harness.Classes.TurnResult'></a>

## TurnResult Class

The outcome of one turn: how it stopped, how many steps and tool calls it took, the token usage and the elapsed time\.

```csharp
public class TurnResult : DiGi.Core.Classes.SerializableObject, DiGi.Harness.Interfaces.IHarnessSerializableObject, DiGi.Harness.Interfaces.IHarnessObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject, DiGi.Core.Interfaces.ISerializableResult, DiGi.Core.Interfaces.IResult
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → TurnResult

Implements [IHarnessSerializableObject](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IHarnessSerializableObject 'DiGi\.Harness\.Interfaces\.IHarnessSerializableObject'), [IHarnessObject](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IHarnessObject 'DiGi\.Harness\.Interfaces\.IHarnessObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject'), [DiGi\.Core\.Interfaces\.ISerializableResult](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableresult 'DiGi\.Core\.Interfaces\.ISerializableResult'), [DiGi\.Core\.Interfaces\.IResult](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iresult 'DiGi\.Core\.Interfaces\.IResult')
### Constructors

<a name='DiGi.Harness.Classes.TurnResult.TurnResult(DiGi.Harness.Classes.TurnResult)'></a>

## TurnResult\(TurnResult\) Constructor

Initializes a new instance of the [TurnResult](DiGi.Harness.Classes.md#DiGi.Harness.Classes.TurnResult 'DiGi\.Harness\.Classes\.TurnResult') class by copying another instance\.

```csharp
public TurnResult(DiGi.Harness.Classes.TurnResult? turnResult);
```
#### Parameters

<a name='DiGi.Harness.Classes.TurnResult.TurnResult(DiGi.Harness.Classes.TurnResult).turnResult'></a>

`turnResult` [TurnResult](DiGi.Harness.Classes.md#DiGi.Harness.Classes.TurnResult 'DiGi\.Harness\.Classes\.TurnResult')

The instance to copy from\.

<a name='DiGi.Harness.Classes.TurnResult.TurnResult(DiGi.Harness.Enums.StopReason,DiGi.Harness.Enums.ErrorCategory,string,int,int,DiGi.Harness.Classes.Usage,double)'></a>

## TurnResult\(StopReason, ErrorCategory, string, int, int, Usage, double\) Constructor

Initializes a new instance of the [TurnResult](DiGi.Harness.Classes.md#DiGi.Harness.Classes.TurnResult 'DiGi\.Harness\.Classes\.TurnResult') class\.

```csharp
public TurnResult(DiGi.Harness.Enums.StopReason stopReason, DiGi.Harness.Enums.ErrorCategory errorCategory, string? errorMessage, int steps, int toolCalls, DiGi.Harness.Classes.Usage? usage, double totalMilliseconds);
```
#### Parameters

<a name='DiGi.Harness.Classes.TurnResult.TurnResult(DiGi.Harness.Enums.StopReason,DiGi.Harness.Enums.ErrorCategory,string,int,int,DiGi.Harness.Classes.Usage,double).stopReason'></a>

`stopReason` [StopReason](DiGi.Harness.Enums.md#DiGi.Harness.Enums.StopReason 'DiGi\.Harness\.Enums\.StopReason')

The stop reason of the last model request\.

<a name='DiGi.Harness.Classes.TurnResult.TurnResult(DiGi.Harness.Enums.StopReason,DiGi.Harness.Enums.ErrorCategory,string,int,int,DiGi.Harness.Classes.Usage,double).errorCategory'></a>

`errorCategory` [ErrorCategory](DiGi.Harness.Enums.md#DiGi.Harness.Enums.ErrorCategory 'DiGi\.Harness\.Enums\.ErrorCategory')

Why the turn did not finish normally, or [Undefined](DiGi.Harness.Enums.md#DiGi.Harness.Enums.ErrorCategory.Undefined 'DiGi\.Harness\.Enums\.ErrorCategory\.Undefined')\.

<a name='DiGi.Harness.Classes.TurnResult.TurnResult(DiGi.Harness.Enums.StopReason,DiGi.Harness.Enums.ErrorCategory,string,int,int,DiGi.Harness.Classes.Usage,double).errorMessage'></a>

`errorMessage` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

A short, key\-free description of the error\.

<a name='DiGi.Harness.Classes.TurnResult.TurnResult(DiGi.Harness.Enums.StopReason,DiGi.Harness.Enums.ErrorCategory,string,int,int,DiGi.Harness.Classes.Usage,double).steps'></a>

`steps` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of model requests made\.

<a name='DiGi.Harness.Classes.TurnResult.TurnResult(DiGi.Harness.Enums.StopReason,DiGi.Harness.Enums.ErrorCategory,string,int,int,DiGi.Harness.Classes.Usage,double).toolCalls'></a>

`toolCalls` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of tool calls run\.

<a name='DiGi.Harness.Classes.TurnResult.TurnResult(DiGi.Harness.Enums.StopReason,DiGi.Harness.Enums.ErrorCategory,string,int,int,DiGi.Harness.Classes.Usage,double).usage'></a>

`usage` [Usage](DiGi.Harness.Classes.md#DiGi.Harness.Classes.Usage 'DiGi\.Harness\.Classes\.Usage')

The token usage summed over every request\.

<a name='DiGi.Harness.Classes.TurnResult.TurnResult(DiGi.Harness.Enums.StopReason,DiGi.Harness.Enums.ErrorCategory,string,int,int,DiGi.Harness.Classes.Usage,double).totalMilliseconds'></a>

`totalMilliseconds` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The duration of the turn in milliseconds\.

<a name='DiGi.Harness.Classes.TurnResult.TurnResult(System.Text.Json.Nodes.JsonObject)'></a>

## TurnResult\(JsonObject\) Constructor

Initializes a new instance of the [TurnResult](DiGi.Harness.Classes.md#DiGi.Harness.Classes.TurnResult 'DiGi\.Harness\.Classes\.TurnResult') class from a JSON object\.

```csharp
public TurnResult(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Harness.Classes.TurnResult.TurnResult(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object to read from\.
### Properties

<a name='DiGi.Harness.Classes.TurnResult.ErrorCategory'></a>

## TurnResult\.ErrorCategory Property

Gets why the turn did not finish normally, or [Undefined](DiGi.Harness.Enums.md#DiGi.Harness.Enums.ErrorCategory.Undefined 'DiGi\.Harness\.Enums\.ErrorCategory\.Undefined')\.

```csharp
public DiGi.Harness.Enums.ErrorCategory ErrorCategory { get; }
```

#### Property Value
[ErrorCategory](DiGi.Harness.Enums.md#DiGi.Harness.Enums.ErrorCategory 'DiGi\.Harness\.Enums\.ErrorCategory')

<a name='DiGi.Harness.Classes.TurnResult.ErrorMessage'></a>

## TurnResult\.ErrorMessage Property

Gets a short, key\-free description of the error\.

```csharp
public string? ErrorMessage { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Classes.TurnResult.Steps'></a>

## TurnResult\.Steps Property

Gets the number of model requests made\.

```csharp
public int Steps { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.Harness.Classes.TurnResult.StopReason'></a>

## TurnResult\.StopReason Property

Gets the stop reason of the last model request\.

```csharp
public DiGi.Harness.Enums.StopReason StopReason { get; }
```

#### Property Value
[StopReason](DiGi.Harness.Enums.md#DiGi.Harness.Enums.StopReason 'DiGi\.Harness\.Enums\.StopReason')

<a name='DiGi.Harness.Classes.TurnResult.ToolCalls'></a>

## TurnResult\.ToolCalls Property

Gets the number of tool calls run\.

```csharp
public int ToolCalls { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.Harness.Classes.TurnResult.TotalMilliseconds'></a>

## TurnResult\.TotalMilliseconds Property

Gets the duration of the turn in milliseconds\.

```csharp
public double TotalMilliseconds { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Harness.Classes.TurnResult.Usage'></a>

## TurnResult\.Usage Property

Gets the token usage summed over every request\.

```csharp
public DiGi.Harness.Classes.Usage? Usage { get; }
```

#### Property Value
[Usage](DiGi.Harness.Classes.md#DiGi.Harness.Classes.Usage 'DiGi\.Harness\.Classes\.Usage')

<a name='DiGi.Harness.Classes.Usage'></a>

## Usage Class

Token usage reported by a provider\.

```csharp
public class Usage : DiGi.Core.Classes.SerializableObject, DiGi.Harness.Interfaces.IHarnessSerializableObject, DiGi.Harness.Interfaces.IHarnessObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → Usage

Implements [IHarnessSerializableObject](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IHarnessSerializableObject 'DiGi\.Harness\.Interfaces\.IHarnessSerializableObject'), [IHarnessObject](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IHarnessObject 'DiGi\.Harness\.Interfaces\.IHarnessObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Harness.Classes.Usage.Usage(DiGi.Harness.Classes.Usage)'></a>

## Usage\(Usage\) Constructor

Initializes a new instance of the [Usage](DiGi.Harness.Classes.md#DiGi.Harness.Classes.Usage 'DiGi\.Harness\.Classes\.Usage') class by copying another instance\.

```csharp
public Usage(DiGi.Harness.Classes.Usage? usage);
```
#### Parameters

<a name='DiGi.Harness.Classes.Usage.Usage(DiGi.Harness.Classes.Usage).usage'></a>

`usage` [Usage](DiGi.Harness.Classes.md#DiGi.Harness.Classes.Usage 'DiGi\.Harness\.Classes\.Usage')

The instance to copy from\.

<a name='DiGi.Harness.Classes.Usage.Usage(int,int,int,int)'></a>

## Usage\(int, int, int, int\) Constructor

Initializes a new instance of the [Usage](DiGi.Harness.Classes.md#DiGi.Harness.Classes.Usage 'DiGi\.Harness\.Classes\.Usage') class\.

```csharp
public Usage(int inputTokens, int outputTokens, int cacheReadInputTokens, int cacheCreationInputTokens);
```
#### Parameters

<a name='DiGi.Harness.Classes.Usage.Usage(int,int,int,int).inputTokens'></a>

`inputTokens` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The uncached input tokens\.

<a name='DiGi.Harness.Classes.Usage.Usage(int,int,int,int).outputTokens'></a>

`outputTokens` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The output tokens\.

<a name='DiGi.Harness.Classes.Usage.Usage(int,int,int,int).cacheReadInputTokens'></a>

`cacheReadInputTokens` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The input tokens read from the prompt cache\.

<a name='DiGi.Harness.Classes.Usage.Usage(int,int,int,int).cacheCreationInputTokens'></a>

`cacheCreationInputTokens` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The input tokens written to the prompt cache\.

<a name='DiGi.Harness.Classes.Usage.Usage(System.Text.Json.Nodes.JsonObject)'></a>

## Usage\(JsonObject\) Constructor

Initializes a new instance of the [Usage](DiGi.Harness.Classes.md#DiGi.Harness.Classes.Usage 'DiGi\.Harness\.Classes\.Usage') class from a JSON object\.

```csharp
public Usage(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Harness.Classes.Usage.Usage(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object to read from\.
### Properties

<a name='DiGi.Harness.Classes.Usage.CacheCreationInputTokens'></a>

## Usage\.CacheCreationInputTokens Property

Gets the input tokens written to the prompt cache\.

```csharp
public int CacheCreationInputTokens { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.Harness.Classes.Usage.CacheReadInputTokens'></a>

## Usage\.CacheReadInputTokens Property

Gets the input tokens read from the prompt cache\.

```csharp
public int CacheReadInputTokens { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.Harness.Classes.Usage.InputTokens'></a>

## Usage\.InputTokens Property

Gets the uncached input tokens\.

```csharp
public int InputTokens { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.Harness.Classes.Usage.OutputTokens'></a>

## Usage\.OutputTokens Property

Gets the output tokens\.

```csharp
public int OutputTokens { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.Harness.Classes.UsageEvent'></a>

## UsageEvent Class

The token usage of one model request\.

```csharp
public class UsageEvent : DiGi.Harness.Classes.HarnessEvent
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [HarnessEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.HarnessEvent 'DiGi\.Harness\.Classes\.HarnessEvent') → UsageEvent
### Constructors

<a name='DiGi.Harness.Classes.UsageEvent.UsageEvent(DiGi.Harness.Classes.Usage,double)'></a>

## UsageEvent\(Usage, double\) Constructor

Initializes a new instance of the [UsageEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.UsageEvent 'DiGi\.Harness\.Classes\.UsageEvent') class\.

```csharp
public UsageEvent(DiGi.Harness.Classes.Usage? usage, double elapsedMilliseconds);
```
#### Parameters

<a name='DiGi.Harness.Classes.UsageEvent.UsageEvent(DiGi.Harness.Classes.Usage,double).usage'></a>

`usage` [Usage](DiGi.Harness.Classes.md#DiGi.Harness.Classes.Usage 'DiGi\.Harness\.Classes\.Usage')

The token usage of the request\.

<a name='DiGi.Harness.Classes.UsageEvent.UsageEvent(DiGi.Harness.Classes.Usage,double).elapsedMilliseconds'></a>

`elapsedMilliseconds` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The time elapsed since the turn started, in milliseconds\.

<a name='DiGi.Harness.Classes.UsageEvent.UsageEvent(DiGi.Harness.Classes.UsageEvent)'></a>

## UsageEvent\(UsageEvent\) Constructor

Initializes a new instance of the [UsageEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.UsageEvent 'DiGi\.Harness\.Classes\.UsageEvent') class by copying another instance\.

```csharp
public UsageEvent(DiGi.Harness.Classes.UsageEvent? usageEvent);
```
#### Parameters

<a name='DiGi.Harness.Classes.UsageEvent.UsageEvent(DiGi.Harness.Classes.UsageEvent).usageEvent'></a>

`usageEvent` [UsageEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.UsageEvent 'DiGi\.Harness\.Classes\.UsageEvent')

The instance to copy from\.

<a name='DiGi.Harness.Classes.UsageEvent.UsageEvent(System.Text.Json.Nodes.JsonObject)'></a>

## UsageEvent\(JsonObject\) Constructor

Initializes a new instance of the [UsageEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.UsageEvent 'DiGi\.Harness\.Classes\.UsageEvent') class from a JSON object\.

```csharp
public UsageEvent(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Harness.Classes.UsageEvent.UsageEvent(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object to read from\.
### Properties

<a name='DiGi.Harness.Classes.UsageEvent.Usage'></a>

## UsageEvent\.Usage Property

Gets the token usage of the request\.

```csharp
public DiGi.Harness.Classes.Usage? Usage { get; }
```

#### Property Value
[Usage](DiGi.Harness.Classes.md#DiGi.Harness.Classes.Usage 'DiGi\.Harness\.Classes\.Usage')