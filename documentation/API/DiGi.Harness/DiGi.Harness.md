#### [DiGi\.Harness](DiGi.Harness.Overview.md 'DiGi\.Harness\.Overview')

## DiGi\.Harness Namespace
### Classes

<a name='DiGi.Harness.Convert'></a>

## Convert Class

```csharp
public static class Convert
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Convert
### Methods

<a name='DiGi.Harness.Convert.ToAnthropic_JsonObject(thisDiGi.Harness.Classes.Conversation,DiGi.Harness.Classes.ProviderConfiguration,System.Collections.Generic.IEnumerable_DiGi.Harness.Classes.ToolDefinition_,string)'></a>

## Convert\.ToAnthropic\_JsonObject\(this Conversation, ProviderConfiguration, IEnumerable\<ToolDefinition\>, string\) Method

Builds the body of a streamed Anthropic Messages request \(`POST /v1/messages`\) from a conversation\.

The system prompt is one cached text block (`cache_control: ephemeral`), so the tools and the system prompt form a stable cached prefix. Tools use `tool_choice: auto` (forced tool choice is rejected by current models). Thinking is `{"type":"adaptive","display":"summarized"}` when [Thinking](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ProviderConfiguration.Thinking 'DiGi\.Harness\.Classes\.ProviderConfiguration\.Thinking') is set; effort goes to `output_config.effort`; `fallbacks: "default"` is sent when [AnthropicFallbacks](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ProviderConfiguration.AnthropicFallbacks 'DiGi\.Harness\.Classes\.ProviderConfiguration\.AnthropicFallbacks') is set. Thinking blocks are replayed unchanged with their signatures.

```csharp
public static System.Text.Json.Nodes.JsonObject? ToAnthropic_JsonObject(this DiGi.Harness.Classes.Conversation? conversation, DiGi.Harness.Classes.ProviderConfiguration? providerConfiguration, System.Collections.Generic.IEnumerable<DiGi.Harness.Classes.ToolDefinition>? toolDefinitions, string? systemPrompt);
```
#### Parameters

<a name='DiGi.Harness.Convert.ToAnthropic_JsonObject(thisDiGi.Harness.Classes.Conversation,DiGi.Harness.Classes.ProviderConfiguration,System.Collections.Generic.IEnumerable_DiGi.Harness.Classes.ToolDefinition_,string).conversation'></a>

`conversation` [Conversation](DiGi.Harness.Classes.md#DiGi.Harness.Classes.Conversation 'DiGi\.Harness\.Classes\.Conversation')

The conversation\.

<a name='DiGi.Harness.Convert.ToAnthropic_JsonObject(thisDiGi.Harness.Classes.Conversation,DiGi.Harness.Classes.ProviderConfiguration,System.Collections.Generic.IEnumerable_DiGi.Harness.Classes.ToolDefinition_,string).providerConfiguration'></a>

`providerConfiguration` [ProviderConfiguration](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ProviderConfiguration 'DiGi\.Harness\.Classes\.ProviderConfiguration')

The provider\.

<a name='DiGi.Harness.Convert.ToAnthropic_JsonObject(thisDiGi.Harness.Classes.Conversation,DiGi.Harness.Classes.ProviderConfiguration,System.Collections.Generic.IEnumerable_DiGi.Harness.Classes.ToolDefinition_,string).toolDefinitions'></a>

`toolDefinitions` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[ToolDefinition](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolDefinition 'DiGi\.Harness\.Classes\.ToolDefinition')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The tools offered to the model, or null for none\.

<a name='DiGi.Harness.Convert.ToAnthropic_JsonObject(thisDiGi.Harness.Classes.Conversation,DiGi.Harness.Classes.ProviderConfiguration,System.Collections.Generic.IEnumerable_DiGi.Harness.Classes.ToolDefinition_,string).systemPrompt'></a>

`systemPrompt` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The system prompt, or null for none\.

#### Returns
[System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')  
The request body, or null when the conversation or provider is null\.

<a name='DiGi.Harness.Convert.ToHarness_Message(thisDiGi.Harness.Classes.CompletionState)'></a>

## Convert\.ToHarness\_Message\(this CompletionState\) Method

Turns the accumulated state of a streamed response into the assistant message, blocks in stream order\.

Empty text blocks are dropped. A thinking block is kept when it has text, a signature or redacted data, since an Anthropic block with empty text still has to be replayed. A tool call keeps its input JSON exactly as streamed; an empty input becomes `{}`.

```csharp
public static DiGi.Harness.Classes.Message? ToHarness_Message(this DiGi.Harness.Classes.CompletionState? completionState);
```
#### Parameters

<a name='DiGi.Harness.Convert.ToHarness_Message(thisDiGi.Harness.Classes.CompletionState).completionState'></a>

`completionState` [CompletionState](DiGi.Harness.Classes.md#DiGi.Harness.Classes.CompletionState 'DiGi\.Harness\.Classes\.CompletionState')

The accumulated state\.

#### Returns
[Message](DiGi.Harness.Classes.md#DiGi.Harness.Classes.Message 'DiGi\.Harness\.Classes\.Message')  
The assistant message, or null when [completionState](DiGi.Harness.md#DiGi.Harness.Convert.ToHarness_Message(thisDiGi.Harness.Classes.CompletionState).completionState 'DiGi\.Harness\.Convert\.ToHarness\_Message\(this DiGi\.Harness\.Classes\.CompletionState\)\.completionState') is null\.

<a name='DiGi.Harness.Convert.ToHarness_StopReason(thisstring)'></a>

## Convert\.ToHarness\_StopReason\(this string\) Method

Maps a provider stop reason \(Anthropic `stop_reason`, OpenAI `finish_reason`\) to a [StopReason](DiGi.Harness.Enums.md#DiGi.Harness.Enums.StopReason 'DiGi\.Harness\.Enums\.StopReason')\.

```csharp
public static DiGi.Harness.Enums.StopReason ToHarness_StopReason(this string? text);
```
#### Parameters

<a name='DiGi.Harness.Convert.ToHarness_StopReason(thisstring).text'></a>

`text` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The provider value, such as `end_turn`, `tool_use`, `stop` or `tool_calls`\.

#### Returns
[StopReason](DiGi.Harness.Enums.md#DiGi.Harness.Enums.StopReason 'DiGi\.Harness\.Enums\.StopReason')  
The stop reason; [Undefined](DiGi.Harness.Enums.md#DiGi.Harness.Enums.StopReason.Undefined 'DiGi\.Harness\.Enums\.StopReason\.Undefined') for null or empty, [Other](DiGi.Harness.Enums.md#DiGi.Harness.Enums.StopReason.Other 'DiGi\.Harness\.Enums\.StopReason\.Other') for an unknown value\.

<a name='DiGi.Harness.Convert.ToOpenAI_JsonObject(thisDiGi.Harness.Classes.Conversation,DiGi.Harness.Classes.ProviderConfiguration,System.Collections.Generic.IEnumerable_DiGi.Harness.Classes.ToolDefinition_,string)'></a>

## Convert\.ToOpenAI\_JsonObject\(this Conversation, ProviderConfiguration, IEnumerable\<ToolDefinition\>, string\) Method

Builds the body of a streamed OpenAI Chat Completions request \(`POST /chat/completions`\) from a conversation\.

Tool results become `role: tool` messages placed before any user text of the same message. Assistant tool calls carry their input as the `arguments` string. Reasoning is replayed as `reasoning_content` only when [ReplayReasoning](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ProviderConfiguration.ReplayReasoning 'DiGi\.Harness\.Classes\.ProviderConfiguration\.ReplayReasoning') is set (DeepSeek thinking mode with tools needs it; most servers ignore or reject it). Effort goes to `reasoning_effort`; usage is requested with `stream_options.include_usage`.

```csharp
public static System.Text.Json.Nodes.JsonObject? ToOpenAI_JsonObject(this DiGi.Harness.Classes.Conversation? conversation, DiGi.Harness.Classes.ProviderConfiguration? providerConfiguration, System.Collections.Generic.IEnumerable<DiGi.Harness.Classes.ToolDefinition>? toolDefinitions, string? systemPrompt);
```
#### Parameters

<a name='DiGi.Harness.Convert.ToOpenAI_JsonObject(thisDiGi.Harness.Classes.Conversation,DiGi.Harness.Classes.ProviderConfiguration,System.Collections.Generic.IEnumerable_DiGi.Harness.Classes.ToolDefinition_,string).conversation'></a>

`conversation` [Conversation](DiGi.Harness.Classes.md#DiGi.Harness.Classes.Conversation 'DiGi\.Harness\.Classes\.Conversation')

The conversation\.

<a name='DiGi.Harness.Convert.ToOpenAI_JsonObject(thisDiGi.Harness.Classes.Conversation,DiGi.Harness.Classes.ProviderConfiguration,System.Collections.Generic.IEnumerable_DiGi.Harness.Classes.ToolDefinition_,string).providerConfiguration'></a>

`providerConfiguration` [ProviderConfiguration](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ProviderConfiguration 'DiGi\.Harness\.Classes\.ProviderConfiguration')

The provider\.

<a name='DiGi.Harness.Convert.ToOpenAI_JsonObject(thisDiGi.Harness.Classes.Conversation,DiGi.Harness.Classes.ProviderConfiguration,System.Collections.Generic.IEnumerable_DiGi.Harness.Classes.ToolDefinition_,string).toolDefinitions'></a>

`toolDefinitions` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[ToolDefinition](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolDefinition 'DiGi\.Harness\.Classes\.ToolDefinition')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The tools offered to the model, or null for none\.

<a name='DiGi.Harness.Convert.ToOpenAI_JsonObject(thisDiGi.Harness.Classes.Conversation,DiGi.Harness.Classes.ProviderConfiguration,System.Collections.Generic.IEnumerable_DiGi.Harness.Classes.ToolDefinition_,string).systemPrompt'></a>

`systemPrompt` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The system prompt, or null for none\.

#### Returns
[System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')  
The request body, or null when the conversation or provider is null\.

<a name='DiGi.Harness.Create'></a>

## Create Class

```csharp
public static class Create
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Create
### Methods

<a name='DiGi.Harness.Create.ConversationExport(DiGi.Harness.Classes.Conversation,DiGi.Harness.Enums.ExportMode,System.DateTimeOffset,string)'></a>

## Create\.ConversationExport\(Conversation, ExportMode, DateTimeOffset, string\) Method

Builds the export of a conversation\.

The conversation is filtered with [Export\(this Conversation, ExportMode\)](DiGi.Harness.md#DiGi.Harness.Query.Export(thisDiGi.Harness.Classes.Conversation,DiGi.Harness.Enums.ExportMode) 'DiGi\.Harness\.Query\.Export\(this DiGi\.Harness\.Classes\.Conversation, DiGi\.Harness\.Enums\.ExportMode\)'); [Undefined](DiGi.Harness.Enums.md#DiGi.Harness.Enums.ExportMode.Undefined 'DiGi\.Harness\.Enums\.ExportMode\.Undefined') is stored as [Messages](DiGi.Harness.Enums.md#DiGi.Harness.Enums.ExportMode.Messages 'DiGi\.Harness\.Enums\.ExportMode\.Messages').

```csharp
public static DiGi.Harness.Classes.ConversationExport? ConversationExport(DiGi.Harness.Classes.Conversation? conversation, DiGi.Harness.Enums.ExportMode exportMode, System.DateTimeOffset exportedAt, string? version);
```
#### Parameters

<a name='DiGi.Harness.Create.ConversationExport(DiGi.Harness.Classes.Conversation,DiGi.Harness.Enums.ExportMode,System.DateTimeOffset,string).conversation'></a>

`conversation` [Conversation](DiGi.Harness.Classes.md#DiGi.Harness.Classes.Conversation 'DiGi\.Harness\.Classes\.Conversation')

The conversation\.

<a name='DiGi.Harness.Create.ConversationExport(DiGi.Harness.Classes.Conversation,DiGi.Harness.Enums.ExportMode,System.DateTimeOffset,string).exportMode'></a>

`exportMode` [ExportMode](DiGi.Harness.Enums.md#DiGi.Harness.Enums.ExportMode 'DiGi\.Harness\.Enums\.ExportMode')

The export mode\.

<a name='DiGi.Harness.Create.ConversationExport(DiGi.Harness.Classes.Conversation,DiGi.Harness.Enums.ExportMode,System.DateTimeOffset,string).exportedAt'></a>

`exportedAt` [System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')

The time of the export\.

<a name='DiGi.Harness.Create.ConversationExport(DiGi.Harness.Classes.Conversation,DiGi.Harness.Enums.ExportMode,System.DateTimeOffset,string).version'></a>

`version` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The version of the harness that produced the export \(for example the assembly informational version\)\.

#### Returns
[ConversationExport](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ConversationExport 'DiGi\.Harness\.Classes\.ConversationExport')  
The export, or null when [conversation](DiGi.Harness.md#DiGi.Harness.Create.ConversationExport(DiGi.Harness.Classes.Conversation,DiGi.Harness.Enums.ExportMode,System.DateTimeOffset,string).conversation 'DiGi\.Harness\.Create\.ConversationExport\(DiGi\.Harness\.Classes\.Conversation, DiGi\.Harness\.Enums\.ExportMode, System\.DateTimeOffset, string\)\.conversation') is null\.

<a name='DiGi.Harness.Create.HarnessConfiguration(string)'></a>

## Create\.HarnessConfiguration\(string\) Method

Loads the harness configuration from `Harness.json`\.

Looks at [path](DiGi.Harness.md#DiGi.Harness.Create.HarnessConfiguration(string).path 'DiGi\.Harness\.Create\.HarnessConfiguration\(string\)\.path'), then the application base directory, then the working directory. Fails closed: a missing or unreadable file returns a disabled configuration with no providers. The `_type` discriminators may be left out of the hand-written file; they are filled in before reading. Keys are never logged.

```csharp
public static DiGi.Harness.Classes.HarnessConfiguration HarnessConfiguration(string? path=null);
```
#### Parameters

<a name='DiGi.Harness.Create.HarnessConfiguration(string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

An explicit path to the configuration file, or null to search the default locations\.

#### Returns
[HarnessConfiguration](DiGi.Harness.Classes.md#DiGi.Harness.Classes.HarnessConfiguration 'DiGi\.Harness\.Classes\.HarnessConfiguration')  
The loaded configuration, or a disabled one\.

<a name='DiGi.Harness.Create.HttpRequestMessage(thisDiGi.Harness.Classes.ProviderConfiguration,System.Text.Json.Nodes.JsonObject)'></a>

## Create\.HttpRequestMessage\(this ProviderConfiguration, JsonObject\) Method

Builds the streamed HTTP request of one model call: the endpoint URI, the protocol headers and the JSON body\.

Anthropic: `{BaseUri}/v1/messages` with `x-api-key`, `anthropic-version` and, when fallbacks are on, `anthropic-beta`. OpenAI: `{BaseUri}/chat/completions` with `Authorization: Bearer` when a key is configured.

```csharp
public static System.Net.Http.HttpRequestMessage? HttpRequestMessage(this DiGi.Harness.Classes.ProviderConfiguration? providerConfiguration, System.Text.Json.Nodes.JsonObject? body);
```
#### Parameters

<a name='DiGi.Harness.Create.HttpRequestMessage(thisDiGi.Harness.Classes.ProviderConfiguration,System.Text.Json.Nodes.JsonObject).providerConfiguration'></a>

`providerConfiguration` [ProviderConfiguration](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ProviderConfiguration 'DiGi\.Harness\.Classes\.ProviderConfiguration')

The provider\.

<a name='DiGi.Harness.Create.HttpRequestMessage(thisDiGi.Harness.Classes.ProviderConfiguration,System.Text.Json.Nodes.JsonObject).body'></a>

`body` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The request body built by [ToAnthropic\_JsonObject\(this Conversation, ProviderConfiguration, IEnumerable&lt;ToolDefinition&gt;, string\)](DiGi.Harness.md#DiGi.Harness.Convert.ToAnthropic_JsonObject(thisDiGi.Harness.Classes.Conversation,DiGi.Harness.Classes.ProviderConfiguration,System.Collections.Generic.IEnumerable_DiGi.Harness.Classes.ToolDefinition_,string) 'DiGi\.Harness\.Convert\.ToAnthropic\_JsonObject\(this DiGi\.Harness\.Classes\.Conversation, DiGi\.Harness\.Classes\.ProviderConfiguration, System\.Collections\.Generic\.IEnumerable\<DiGi\.Harness\.Classes\.ToolDefinition\>, string\)') or [ToOpenAI\_JsonObject\(this Conversation, ProviderConfiguration, IEnumerable&lt;ToolDefinition&gt;, string\)](DiGi.Harness.md#DiGi.Harness.Convert.ToOpenAI_JsonObject(thisDiGi.Harness.Classes.Conversation,DiGi.Harness.Classes.ProviderConfiguration,System.Collections.Generic.IEnumerable_DiGi.Harness.Classes.ToolDefinition_,string) 'DiGi\.Harness\.Convert\.ToOpenAI\_JsonObject\(this DiGi\.Harness\.Classes\.Conversation, DiGi\.Harness\.Classes\.ProviderConfiguration, System\.Collections\.Generic\.IEnumerable\<DiGi\.Harness\.Classes\.ToolDefinition\>, string\)')\.

#### Returns
[System\.Net\.Http\.HttpRequestMessage](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httprequestmessage 'System\.Net\.Http\.HttpRequestMessage')  
The request, or null when the provider is not usable or the body is null\.

<a name='DiGi.Harness.Create.OpenApiIndex(thisSystem.Text.Json.Nodes.JsonObject,string,System.Collections.Generic.IEnumerable_string_)'></a>

## Create\.OpenApiIndex\(this JsonObject, string, IEnumerable\<string\>\) Method

Builds a compact index of an OpenAPI document for a system prompt: one line per operation, `METHOD path — summary (parameter*: type, …) body: Schema`\.

A `*` marks a required parameter. Summaries are cut to their first sentence. Only operations whose path starts with [pathPrefix](DiGi.Harness.md#DiGi.Harness.Create.OpenApiIndex(thisSystem.Text.Json.Nodes.JsonObject,string,System.Collections.Generic.IEnumerable_string_).pathPrefix 'DiGi\.Harness\.Create\.OpenApiIndex\(this System\.Text\.Json\.Nodes\.JsonObject, string, System\.Collections\.Generic\.IEnumerable\<string\>\)\.pathPrefix') are listed, and only the methods named in [methods](DiGi.Harness.md#DiGi.Harness.Create.OpenApiIndex(thisSystem.Text.Json.Nodes.JsonObject,string,System.Collections.Generic.IEnumerable_string_).methods 'DiGi\.Harness\.Create\.OpenApiIndex\(this System\.Text\.Json\.Nodes\.JsonObject, string, System\.Collections\.Generic\.IEnumerable\<string\>\)\.methods') (GET and POST when null).

```csharp
public static string? OpenApiIndex(this System.Text.Json.Nodes.JsonObject? swagger, string? pathPrefix=null, System.Collections.Generic.IEnumerable<string>? methods=null);
```
#### Parameters

<a name='DiGi.Harness.Create.OpenApiIndex(thisSystem.Text.Json.Nodes.JsonObject,string,System.Collections.Generic.IEnumerable_string_).swagger'></a>

`swagger` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The OpenAPI document\.

<a name='DiGi.Harness.Create.OpenApiIndex(thisSystem.Text.Json.Nodes.JsonObject,string,System.Collections.Generic.IEnumerable_string_).pathPrefix'></a>

`pathPrefix` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path prefix to keep, such as `/gis/`; null keeps every path\.

<a name='DiGi.Harness.Create.OpenApiIndex(thisSystem.Text.Json.Nodes.JsonObject,string,System.Collections.Generic.IEnumerable_string_).methods'></a>

`methods` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The HTTP methods to list, any case; null lists GET and POST\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The index text, or null when the document has no paths\.

<a name='DiGi.Harness.Modify'></a>

## Modify Class

```csharp
public static class Modify
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Modify
### Methods

<a name='DiGi.Harness.Modify.Add(thisDiGi.Harness.Classes.Conversation,DiGi.Harness.Classes.Message)'></a>

## Modify\.Add\(this Conversation, Message\) Method

Appends a message to a conversation; the history is append\-only, so this is its only mutation\.

Consecutive messages of the same role are kept as they are: both protocols accept them, and merging would edit history already sent.

```csharp
public static bool Add(this DiGi.Harness.Classes.Conversation? conversation, DiGi.Harness.Classes.Message? message);
```
#### Parameters

<a name='DiGi.Harness.Modify.Add(thisDiGi.Harness.Classes.Conversation,DiGi.Harness.Classes.Message).conversation'></a>

`conversation` [Conversation](DiGi.Harness.Classes.md#DiGi.Harness.Classes.Conversation 'DiGi\.Harness\.Classes\.Conversation')

The conversation\.

<a name='DiGi.Harness.Modify.Add(thisDiGi.Harness.Classes.Conversation,DiGi.Harness.Classes.Message).message'></a>

`message` [Message](DiGi.Harness.Classes.md#DiGi.Harness.Classes.Message 'DiGi\.Harness\.Classes\.Message')

The message to append\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True when the message was appended\.

<a name='DiGi.Harness.Modify.CompleteAsync(thisSystem.Net.Http.HttpClient,DiGi.Harness.Classes.ProviderConfiguration,System.Text.Json.Nodes.JsonObject,System.Func_DiGi.Harness.Classes.HarnessEvent,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Diagnostics.Stopwatch,System.Threading.CancellationToken)'></a>

## Modify\.CompleteAsync\(this HttpClient, ProviderConfiguration, JsonObject, Func\<HarnessEvent,CancellationToken,Task\>, Stopwatch, CancellationToken\) Method

Sends one streamed model request and reads the response to its end, emitting text and thinking events as they arrive\.

Failures are returned, not thrown: no answer (connection failure, timeout, a dropped stream) is [Unavailable](DiGi.Harness.Enums.md#DiGi.Harness.Enums.ErrorCategory.Unavailable 'DiGi\.Harness\.Enums\.ErrorCategory\.Unavailable'); a failure status or an error event inside the stream is [UpstreamFault](DiGi.Harness.Enums.md#DiGi.Harness.Enums.ErrorCategory.UpstreamFault 'DiGi\.Harness\.Enums\.ErrorCategory\.UpstreamFault'). Error messages quote at most a short part of the upstream body and never the key. Only a requested cancellation is rethrown.

```csharp
public static System.Threading.Tasks.Task<DiGi.Harness.Classes.CompletionResult> CompleteAsync(this System.Net.Http.HttpClient? httpClient, DiGi.Harness.Classes.ProviderConfiguration? providerConfiguration, System.Text.Json.Nodes.JsonObject? body, System.Func<DiGi.Harness.Classes.HarnessEvent,System.Threading.CancellationToken,System.Threading.Tasks.Task>? func, System.Diagnostics.Stopwatch? stopwatch, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.Harness.Modify.CompleteAsync(thisSystem.Net.Http.HttpClient,DiGi.Harness.Classes.ProviderConfiguration,System.Text.Json.Nodes.JsonObject,System.Func_DiGi.Harness.Classes.HarnessEvent,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Diagnostics.Stopwatch,System.Threading.CancellationToken).httpClient'></a>

`httpClient` [System\.Net\.Http\.HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient 'System\.Net\.Http\.HttpClient')

The HTTP client; its timeout bounds the whole request\.

<a name='DiGi.Harness.Modify.CompleteAsync(thisSystem.Net.Http.HttpClient,DiGi.Harness.Classes.ProviderConfiguration,System.Text.Json.Nodes.JsonObject,System.Func_DiGi.Harness.Classes.HarnessEvent,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Diagnostics.Stopwatch,System.Threading.CancellationToken).providerConfiguration'></a>

`providerConfiguration` [ProviderConfiguration](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ProviderConfiguration 'DiGi\.Harness\.Classes\.ProviderConfiguration')

The provider\.

<a name='DiGi.Harness.Modify.CompleteAsync(thisSystem.Net.Http.HttpClient,DiGi.Harness.Classes.ProviderConfiguration,System.Text.Json.Nodes.JsonObject,System.Func_DiGi.Harness.Classes.HarnessEvent,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Diagnostics.Stopwatch,System.Threading.CancellationToken).body'></a>

`body` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The request body for the provider's protocol\.

<a name='DiGi.Harness.Modify.CompleteAsync(thisSystem.Net.Http.HttpClient,DiGi.Harness.Classes.ProviderConfiguration,System.Text.Json.Nodes.JsonObject,System.Func_DiGi.Harness.Classes.HarnessEvent,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Diagnostics.Stopwatch,System.Threading.CancellationToken).func'></a>

`func` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[HarnessEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.HarnessEvent 'DiGi\.Harness\.Classes\.HarnessEvent')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')

The handler receiving text and thinking events, or null\.

<a name='DiGi.Harness.Modify.CompleteAsync(thisSystem.Net.Http.HttpClient,DiGi.Harness.Classes.ProviderConfiguration,System.Text.Json.Nodes.JsonObject,System.Func_DiGi.Harness.Classes.HarnessEvent,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Diagnostics.Stopwatch,System.Threading.CancellationToken).stopwatch'></a>

`stopwatch` [System\.Diagnostics\.Stopwatch](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.stopwatch 'System\.Diagnostics\.Stopwatch')

The stopwatch of the turn, used to stamp events; null stamps zero\.

<a name='DiGi.Harness.Modify.CompleteAsync(thisSystem.Net.Http.HttpClient,DiGi.Harness.Classes.ProviderConfiguration,System.Text.Json.Nodes.JsonObject,System.Func_DiGi.Harness.Classes.HarnessEvent,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Diagnostics.Stopwatch,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token that cancels the request\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[CompletionResult](DiGi.Harness.Classes.md#DiGi.Harness.Classes.CompletionResult 'DiGi\.Harness\.Classes\.CompletionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The completion result\.

<a name='DiGi.Harness.Modify.ReadServerSentEventsAsync(thisSystem.IO.Stream,System.Func_DiGi.Harness.Classes.ServerSentEvent,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Threading.CancellationToken)'></a>

## Modify\.ReadServerSentEventsAsync\(this Stream, Func\<ServerSentEvent,CancellationToken,Task\>, CancellationToken\) Method

Reads a `text/event-stream` to its end and hands each event to [func](DiGi.Harness.md#DiGi.Harness.Modify.ReadServerSentEventsAsync(thisSystem.IO.Stream,System.Func_DiGi.Harness.Classes.ServerSentEvent,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Threading.CancellationToken).func 'DiGi\.Harness\.Modify\.ReadServerSentEventsAsync\(this System\.IO\.Stream, System\.Func\<DiGi\.Harness\.Classes\.ServerSentEvent,System\.Threading\.CancellationToken,System\.Threading\.Tasks\.Task\>, System\.Threading\.CancellationToken\)\.func')\.

Follows the SSE format: lines are `field: value`; `data` lines of one event are joined with `\n`; a blank line ends the event; lines starting with `:` are comments. An event without data is skipped. A last event not followed by a blank line is still delivered.

```csharp
public static System.Threading.Tasks.Task<int> ReadServerSentEventsAsync(this System.IO.Stream? stream, System.Func<DiGi.Harness.Classes.ServerSentEvent,System.Threading.CancellationToken,System.Threading.Tasks.Task>? func, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.Harness.Modify.ReadServerSentEventsAsync(thisSystem.IO.Stream,System.Func_DiGi.Harness.Classes.ServerSentEvent,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Threading.CancellationToken).stream'></a>

`stream` [System\.IO\.Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream 'System\.IO\.Stream')

The response stream\.

<a name='DiGi.Harness.Modify.ReadServerSentEventsAsync(thisSystem.IO.Stream,System.Func_DiGi.Harness.Classes.ServerSentEvent,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Threading.CancellationToken).func'></a>

`func` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[ServerSentEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ServerSentEvent 'DiGi\.Harness\.Classes\.ServerSentEvent')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')

The handler called for every event, in order\.

<a name='DiGi.Harness.Modify.ReadServerSentEventsAsync(thisSystem.IO.Stream,System.Func_DiGi.Harness.Classes.ServerSentEvent,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token that stops reading\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The number of events delivered\.

<a name='DiGi.Harness.Modify.RunTurnAsync(thisDiGi.Harness.Classes.Conversation,System.Net.Http.HttpClient,DiGi.Harness.Classes.ProviderConfiguration,System.Collections.Generic.IEnumerable_DiGi.Harness.Interfaces.ITool_,DiGi.Harness.Classes.RunOptions,System.Func_DiGi.Harness.Classes.HarnessEvent,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Threading.CancellationToken)'></a>

## Modify\.RunTurnAsync\(this Conversation, HttpClient, ProviderConfiguration, IEnumerable\<ITool\>, RunOptions, Func\<HarnessEvent,CancellationToken,Task\>, CancellationToken\) Method

Runs one turn of the agent loop on a conversation whose last message is the user's: requests the model, runs the tools it calls, returns their results, and repeats until the model answers without calling a tool\.

Events are handed to [func](DiGi.Harness.md#DiGi.Harness.Modify.RunTurnAsync(thisDiGi.Harness.Classes.Conversation,System.Net.Http.HttpClient,DiGi.Harness.Classes.ProviderConfiguration,System.Collections.Generic.IEnumerable_DiGi.Harness.Interfaces.ITool_,DiGi.Harness.Classes.RunOptions,System.Func_DiGi.Harness.Classes.HarnessEvent,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Threading.CancellationToken).func 'DiGi\.Harness\.Modify\.RunTurnAsync\(this DiGi\.Harness\.Classes\.Conversation, System\.Net\.Http\.HttpClient, DiGi\.Harness\.Classes\.ProviderConfiguration, System\.Collections\.Generic\.IEnumerable\<DiGi\.Harness\.Interfaces\.ITool\>, DiGi\.Harness\.Classes\.RunOptions, System\.Func\<DiGi\.Harness\.Classes\.HarnessEvent,System\.Threading\.CancellationToken,System\.Threading\.Tasks\.Task\>, System\.Threading\.CancellationToken\)\.func') one at a time, never concurrently. Every step emits [StepStartedEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.StepStartedEvent 'DiGi\.Harness\.Classes\.StepStartedEvent') and [UsageEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.UsageEvent 'DiGi\.Harness\.Classes\.UsageEvent'); every tool call emits [ToolCallStartedEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolCallStartedEvent 'DiGi\.Harness\.Classes\.ToolCallStartedEvent') and [ToolCallCompletedEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolCallCompletedEvent 'DiGi\.Harness\.Classes\.ToolCallCompletedEvent'); the turn always ends with [TurnCompletedEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.TurnCompletedEvent 'DiGi\.Harness\.Classes\.TurnCompletedEvent'), preceded by [ErrorEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ErrorEvent 'DiGi\.Harness\.Classes\.ErrorEvent') when it failed.

The conversation never ends with an unanswered tool call: tool calls the loop does not run (output cut off, a refusal, the iteration limit, a cancellation) get error results. Tool calls of one step run in parallel and their results go back in one message. A tool input that is not a JSON object, or lacks a property the schema requires, is answered with an error result without running the tool. Results longer than [MaxToolResultCharacters](DiGi.Harness.Classes.md#DiGi.Harness.Classes.RunOptions.MaxToolResultCharacters 'DiGi\.Harness\.Classes\.RunOptions\.MaxToolResultCharacters') are truncated with a note. Only a requested cancellation is rethrown.

```csharp
public static System.Threading.Tasks.Task<DiGi.Harness.Classes.TurnResult> RunTurnAsync(this DiGi.Harness.Classes.Conversation? conversation, System.Net.Http.HttpClient? httpClient, DiGi.Harness.Classes.ProviderConfiguration? providerConfiguration, System.Collections.Generic.IEnumerable<DiGi.Harness.Interfaces.ITool>? tools, DiGi.Harness.Classes.RunOptions? runOptions, System.Func<DiGi.Harness.Classes.HarnessEvent,System.Threading.CancellationToken,System.Threading.Tasks.Task>? func, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.Harness.Modify.RunTurnAsync(thisDiGi.Harness.Classes.Conversation,System.Net.Http.HttpClient,DiGi.Harness.Classes.ProviderConfiguration,System.Collections.Generic.IEnumerable_DiGi.Harness.Interfaces.ITool_,DiGi.Harness.Classes.RunOptions,System.Func_DiGi.Harness.Classes.HarnessEvent,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Threading.CancellationToken).conversation'></a>

`conversation` [Conversation](DiGi.Harness.Classes.md#DiGi.Harness.Classes.Conversation 'DiGi\.Harness\.Classes\.Conversation')

The conversation; the turn's messages are appended to it\.

<a name='DiGi.Harness.Modify.RunTurnAsync(thisDiGi.Harness.Classes.Conversation,System.Net.Http.HttpClient,DiGi.Harness.Classes.ProviderConfiguration,System.Collections.Generic.IEnumerable_DiGi.Harness.Interfaces.ITool_,DiGi.Harness.Classes.RunOptions,System.Func_DiGi.Harness.Classes.HarnessEvent,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Threading.CancellationToken).httpClient'></a>

`httpClient` [System\.Net\.Http\.HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient 'System\.Net\.Http\.HttpClient')

The HTTP client used for the model requests\.

<a name='DiGi.Harness.Modify.RunTurnAsync(thisDiGi.Harness.Classes.Conversation,System.Net.Http.HttpClient,DiGi.Harness.Classes.ProviderConfiguration,System.Collections.Generic.IEnumerable_DiGi.Harness.Interfaces.ITool_,DiGi.Harness.Classes.RunOptions,System.Func_DiGi.Harness.Classes.HarnessEvent,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Threading.CancellationToken).providerConfiguration'></a>

`providerConfiguration` [ProviderConfiguration](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ProviderConfiguration 'DiGi\.Harness\.Classes\.ProviderConfiguration')

The provider; it must be the one the conversation is locked to\.

<a name='DiGi.Harness.Modify.RunTurnAsync(thisDiGi.Harness.Classes.Conversation,System.Net.Http.HttpClient,DiGi.Harness.Classes.ProviderConfiguration,System.Collections.Generic.IEnumerable_DiGi.Harness.Interfaces.ITool_,DiGi.Harness.Classes.RunOptions,System.Func_DiGi.Harness.Classes.HarnessEvent,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Threading.CancellationToken).tools'></a>

`tools` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[ITool](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.ITool 'DiGi\.Harness\.Interfaces\.ITool')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The tools offered to the model, or null for none\.

<a name='DiGi.Harness.Modify.RunTurnAsync(thisDiGi.Harness.Classes.Conversation,System.Net.Http.HttpClient,DiGi.Harness.Classes.ProviderConfiguration,System.Collections.Generic.IEnumerable_DiGi.Harness.Interfaces.ITool_,DiGi.Harness.Classes.RunOptions,System.Func_DiGi.Harness.Classes.HarnessEvent,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Threading.CancellationToken).runOptions'></a>

`runOptions` [RunOptions](DiGi.Harness.Classes.md#DiGi.Harness.Classes.RunOptions 'DiGi\.Harness\.Classes\.RunOptions')

The system prompt and limits, or null for the defaults\.

<a name='DiGi.Harness.Modify.RunTurnAsync(thisDiGi.Harness.Classes.Conversation,System.Net.Http.HttpClient,DiGi.Harness.Classes.ProviderConfiguration,System.Collections.Generic.IEnumerable_DiGi.Harness.Interfaces.ITool_,DiGi.Harness.Classes.RunOptions,System.Func_DiGi.Harness.Classes.HarnessEvent,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Threading.CancellationToken).func'></a>

`func` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[HarnessEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.HarnessEvent 'DiGi\.Harness\.Classes\.HarnessEvent')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')

The handler receiving the turn's events, or null\.

<a name='DiGi.Harness.Modify.RunTurnAsync(thisDiGi.Harness.Classes.Conversation,System.Net.Http.HttpClient,DiGi.Harness.Classes.ProviderConfiguration,System.Collections.Generic.IEnumerable_DiGi.Harness.Interfaces.ITool_,DiGi.Harness.Classes.RunOptions,System.Func_DiGi.Harness.Classes.HarnessEvent,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token that cancels the turn\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[TurnResult](DiGi.Harness.Classes.md#DiGi.Harness.Classes.TurnResult 'DiGi\.Harness\.Classes\.TurnResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The outcome of the turn\.

<a name='DiGi.Harness.Modify.Update_Anthropic(thisDiGi.Harness.Classes.CompletionState,System.Text.Json.Nodes.JsonObject,double)'></a>

## Modify\.Update\_Anthropic\(this CompletionState, JsonObject, double\) Method

Applies one Anthropic Messages stream event to the state of a response and returns the events to emit\.

Handles `message_start` (usage), `content_block_start` (text, thinking, redacted_thinking, tool_use), `content_block_delta` (`text_delta`, `thinking_delta`, `signature_delta`, `input_json_delta`), `content_block_stop`, `message_delta` (stop reason, refusal details, output usage) and `error`. Unknown events and block types are ignored.

```csharp
public static System.Collections.Generic.List<DiGi.Harness.Classes.HarnessEvent> Update_Anthropic(this DiGi.Harness.Classes.CompletionState? completionState, System.Text.Json.Nodes.JsonObject? jsonObject, double elapsedMilliseconds);
```
#### Parameters

<a name='DiGi.Harness.Modify.Update_Anthropic(thisDiGi.Harness.Classes.CompletionState,System.Text.Json.Nodes.JsonObject,double).completionState'></a>

`completionState` [CompletionState](DiGi.Harness.Classes.md#DiGi.Harness.Classes.CompletionState 'DiGi\.Harness\.Classes\.CompletionState')

The response state\.

<a name='DiGi.Harness.Modify.Update_Anthropic(thisDiGi.Harness.Classes.CompletionState,System.Text.Json.Nodes.JsonObject,double).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The parsed `data` of the event\.

<a name='DiGi.Harness.Modify.Update_Anthropic(thisDiGi.Harness.Classes.CompletionState,System.Text.Json.Nodes.JsonObject,double).elapsedMilliseconds'></a>

`elapsedMilliseconds` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The time elapsed since the turn started, stamped on the returned events\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[HarnessEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.HarnessEvent 'DiGi\.Harness\.Classes\.HarnessEvent')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
The events to emit \(text and thinking deltas, completed thinking blocks\); empty when there are none\.

<a name='DiGi.Harness.Modify.Update_OpenAI(thisDiGi.Harness.Classes.CompletionState,System.Text.Json.Nodes.JsonObject,double)'></a>

## Modify\.Update\_OpenAI\(this CompletionState, JsonObject, double\) Method

Applies one OpenAI Chat Completions stream chunk to the state of a response and returns the events to emit\.

Reads the first choice's `delta.content`, `delta.reasoning_content` or `delta.reasoning` (DeepSeek, LM Studio and others), indexed `delta.tool_calls` fragments (the id and name arrive once, the `arguments` string in pieces), `finish_reason`, `usage` and an `error` object. Reasoning is kept at position 0, text at 1 and tool call `i` at `2 + i`, so the message lists them in that order; the reasoning block completes when text or a tool call starts.

```csharp
public static System.Collections.Generic.List<DiGi.Harness.Classes.HarnessEvent> Update_OpenAI(this DiGi.Harness.Classes.CompletionState? completionState, System.Text.Json.Nodes.JsonObject? jsonObject, double elapsedMilliseconds);
```
#### Parameters

<a name='DiGi.Harness.Modify.Update_OpenAI(thisDiGi.Harness.Classes.CompletionState,System.Text.Json.Nodes.JsonObject,double).completionState'></a>

`completionState` [CompletionState](DiGi.Harness.Classes.md#DiGi.Harness.Classes.CompletionState 'DiGi\.Harness\.Classes\.CompletionState')

The response state\.

<a name='DiGi.Harness.Modify.Update_OpenAI(thisDiGi.Harness.Classes.CompletionState,System.Text.Json.Nodes.JsonObject,double).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The parsed `data` of the chunk\.

<a name='DiGi.Harness.Modify.Update_OpenAI(thisDiGi.Harness.Classes.CompletionState,System.Text.Json.Nodes.JsonObject,double).elapsedMilliseconds'></a>

`elapsedMilliseconds` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The time elapsed since the turn started, stamped on the returned events\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[HarnessEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.HarnessEvent 'DiGi\.Harness\.Classes\.HarnessEvent')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
The events to emit \(text and thinking deltas, completed thinking\); empty when there are none\.

<a name='DiGi.Harness.Query'></a>

## Query Class

```csharp
public static class Query
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Query
### Methods

<a name='DiGi.Harness.Query.ApiKey(thisDiGi.Harness.Classes.ProviderConfiguration)'></a>

## Query\.ApiKey\(this ProviderConfiguration\) Method

Resolves the API key of a provider: [Key](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ProviderConfiguration.Key 'DiGi\.Harness\.Classes\.ProviderConfiguration\.Key'), or else the environment variable named by [KeyEnvironmentVariable](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ProviderConfiguration.KeyEnvironmentVariable 'DiGi\.Harness\.Classes\.ProviderConfiguration\.KeyEnvironmentVariable')\.

Never log the result or return it to a client.

```csharp
public static string? ApiKey(this DiGi.Harness.Classes.ProviderConfiguration? providerConfiguration);
```
#### Parameters

<a name='DiGi.Harness.Query.ApiKey(thisDiGi.Harness.Classes.ProviderConfiguration).providerConfiguration'></a>

`providerConfiguration` [ProviderConfiguration](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ProviderConfiguration 'DiGi\.Harness\.Classes\.ProviderConfiguration')

The provider\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The API key, or null when none is configured \(a local server\)\.

<a name='DiGi.Harness.Query.Export(thisDiGi.Harness.Classes.Conversation,DiGi.Harness.Enums.ExportMode)'></a>

## Query\.Export\(this Conversation, ExportMode\) Method

Builds the copy of a conversation written to an export file\.

[Messages](DiGi.Harness.Enums.md#DiGi.Harness.Enums.ExportMode.Messages 'DiGi\.Harness\.Enums\.ExportMode\.Messages') (and [Undefined](DiGi.Harness.Enums.md#DiGi.Harness.Enums.ExportMode.Undefined 'DiGi\.Harness\.Enums\.ExportMode\.Undefined')) keeps the text only; [Full](DiGi.Harness.Enums.md#DiGi.Harness.Enums.ExportMode.Full 'DiGi\.Harness\.Enums\.ExportMode\.Full') also keeps the complete thinking text, the tool calls and the tool results. Thinking signatures and redacted thinking data are never copied. A message left without content is dropped; order and roles are kept. The source conversation is not modified.

```csharp
public static DiGi.Harness.Classes.Conversation? Export(this DiGi.Harness.Classes.Conversation? conversation, DiGi.Harness.Enums.ExportMode exportMode);
```
#### Parameters

<a name='DiGi.Harness.Query.Export(thisDiGi.Harness.Classes.Conversation,DiGi.Harness.Enums.ExportMode).conversation'></a>

`conversation` [Conversation](DiGi.Harness.Classes.md#DiGi.Harness.Classes.Conversation 'DiGi\.Harness\.Classes\.Conversation')

The conversation\.

<a name='DiGi.Harness.Query.Export(thisDiGi.Harness.Classes.Conversation,DiGi.Harness.Enums.ExportMode).exportMode'></a>

`exportMode` [ExportMode](DiGi.Harness.Enums.md#DiGi.Harness.Enums.ExportMode 'DiGi\.Harness\.Enums\.ExportMode')

The export mode\.

#### Returns
[Conversation](DiGi.Harness.Classes.md#DiGi.Harness.Classes.Conversation 'DiGi\.Harness\.Classes\.Conversation')  
The filtered copy, or null when [conversation](DiGi.Harness.md#DiGi.Harness.Query.Export(thisDiGi.Harness.Classes.Conversation,DiGi.Harness.Enums.ExportMode).conversation 'DiGi\.Harness\.Query\.Export\(this DiGi\.Harness\.Classes\.Conversation, DiGi\.Harness\.Enums\.ExportMode\)\.conversation') is null\.

<a name='DiGi.Harness.Query.Input(thisDiGi.Harness.Classes.ToolUseContent)'></a>

## Query\.Input\(this ToolUseContent\) Method

Parses the input of a tool call\.

An empty input is an empty object; input that is not a JSON object (invalid, or truncated by the output limit) returns null.

```csharp
public static System.Text.Json.Nodes.JsonObject? Input(this DiGi.Harness.Classes.ToolUseContent? toolUseContent);
```
#### Parameters

<a name='DiGi.Harness.Query.Input(thisDiGi.Harness.Classes.ToolUseContent).toolUseContent'></a>

`toolUseContent` [ToolUseContent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolUseContent 'DiGi\.Harness\.Classes\.ToolUseContent')

The tool call\.

#### Returns
[System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')  
The parsed input, or null when it is not a JSON object\.

<a name='DiGi.Harness.Query.InputSchema(thisDiGi.Harness.Classes.ToolDefinition)'></a>

## Query\.InputSchema\(this ToolDefinition\) Method

Parses the JSON input schema of a tool definition\.

A missing or invalid schema returns the empty object schema `{"type":"object","properties":{}}`, which every protocol accepts.

```csharp
public static System.Text.Json.Nodes.JsonObject? InputSchema(this DiGi.Harness.Classes.ToolDefinition? toolDefinition);
```
#### Parameters

<a name='DiGi.Harness.Query.InputSchema(thisDiGi.Harness.Classes.ToolDefinition).toolDefinition'></a>

`toolDefinition` [ToolDefinition](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolDefinition 'DiGi\.Harness\.Classes\.ToolDefinition')

The tool definition\.

#### Returns
[System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')  
The parsed schema, or null when [toolDefinition](DiGi.Harness.md#DiGi.Harness.Query.InputSchema(thisDiGi.Harness.Classes.ToolDefinition).toolDefinition 'DiGi\.Harness\.Query\.InputSchema\(this DiGi\.Harness\.Classes\.ToolDefinition\)\.toolDefinition') is null\.

<a name='DiGi.Harness.Query.IsAllowed(thisDiGi.Harness.Classes.HarnessConfiguration,string)'></a>

## Query\.IsAllowed\(this HarnessConfiguration, string\) Method

Checks that a user may chat: the harness is enabled, the user id is known, and [AllowedUserIds](DiGi.Harness.Classes.md#DiGi.Harness.Classes.HarnessConfiguration.AllowedUserIds 'DiGi\.Harness\.Classes\.HarnessConfiguration\.AllowedUserIds') is empty or contains it \(ordinal, ignoring case\)\.

```csharp
public static bool IsAllowed(this DiGi.Harness.Classes.HarnessConfiguration? harnessConfiguration, string? userId);
```
#### Parameters

<a name='DiGi.Harness.Query.IsAllowed(thisDiGi.Harness.Classes.HarnessConfiguration,string).harnessConfiguration'></a>

`harnessConfiguration` [HarnessConfiguration](DiGi.Harness.Classes.md#DiGi.Harness.Classes.HarnessConfiguration 'DiGi\.Harness\.Classes\.HarnessConfiguration')

The configuration\.

<a name='DiGi.Harness.Query.IsAllowed(thisDiGi.Harness.Classes.HarnessConfiguration,string).userId'></a>

`userId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The user id resolved by the host; null or empty is never allowed\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True when the user may chat\.

<a name='DiGi.Harness.Query.IsUsable(thisDiGi.Harness.Classes.ProviderConfiguration)'></a>

## Query\.IsUsable\(this ProviderConfiguration\) Method

Checks that a provider can be called: enabled, with a protocol, an absolute HTTP\(S\) base URI, a model and a name\.

The key is not checked: a local server needs none, and a provider that needs one answers 401, reported as an upstream fault.

```csharp
public static bool IsUsable(this DiGi.Harness.Classes.ProviderConfiguration? providerConfiguration);
```
#### Parameters

<a name='DiGi.Harness.Query.IsUsable(thisDiGi.Harness.Classes.ProviderConfiguration).providerConfiguration'></a>

`providerConfiguration` [ProviderConfiguration](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ProviderConfiguration 'DiGi\.Harness\.Classes\.ProviderConfiguration')

The provider\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True when the provider can be called\.

<a name='DiGi.Harness.Query.Operation(thisSystem.Text.Json.Nodes.JsonObject,string,string)'></a>

## Query\.Operation\(this JsonObject, string, string\) Method

Finds one operation of an OpenAPI document by method and request path, with its schemas resolved two levels deep\.

```csharp
public static System.Text.Json.Nodes.JsonObject? Operation(this System.Text.Json.Nodes.JsonObject? swagger, string? method, string? path);
```
#### Parameters

<a name='DiGi.Harness.Query.Operation(thisSystem.Text.Json.Nodes.JsonObject,string,string).swagger'></a>

`swagger` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The OpenAPI document\.

<a name='DiGi.Harness.Query.Operation(thisSystem.Text.Json.Nodes.JsonObject,string,string).method'></a>

`method` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The HTTP method, any case\.

<a name='DiGi.Harness.Query.Operation(thisSystem.Text.Json.Nodes.JsonObject,string,string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The request path or path template, starting with `/`\.

#### Returns
[System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')  
A copy of the operation \(`method`, `path`, then the operation members\), or null when nothing matches\.

<a name='DiGi.Harness.Query.PathTemplate(thisSystem.Text.Json.Nodes.JsonObject,string,string)'></a>

## Query\.PathTemplate\(this JsonObject, string, string\) Method

Finds the OpenAPI path template an actual request path matches, for one HTTP method\.

A literal segment compares ordinal, ignoring case; a `{parameter}` segment matches any one non-empty segment. A path that is absolute (`http://`), protocol-relative (`//host`), contains `..`, a backslash, a percent-encoding, a query (`?`) or a fragment (`#`) never matches, so the result is safe to append to a fixed base URI.

```csharp
public static string? PathTemplate(this System.Text.Json.Nodes.JsonObject? swagger, string? method, string? path);
```
#### Parameters

<a name='DiGi.Harness.Query.PathTemplate(thisSystem.Text.Json.Nodes.JsonObject,string,string).swagger'></a>

`swagger` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The OpenAPI document\.

<a name='DiGi.Harness.Query.PathTemplate(thisSystem.Text.Json.Nodes.JsonObject,string,string).method'></a>

`method` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The HTTP method, any case \(`GET`, `post`\)\.

<a name='DiGi.Harness.Query.PathTemplate(thisSystem.Text.Json.Nodes.JsonObject,string,string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The request path, starting with `/`\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The matched path template as written in the document, or null when nothing matches\.

<a name='DiGi.Harness.Query.ProviderConfiguration(thisDiGi.Harness.Classes.HarnessConfiguration,string)'></a>

## Query\.ProviderConfiguration\(this HarnessConfiguration, string\) Method

Finds a usable provider by name, or the default provider when [name](DiGi.Harness.md#DiGi.Harness.Query.ProviderConfiguration(thisDiGi.Harness.Classes.HarnessConfiguration,string).name 'DiGi\.Harness\.Query\.ProviderConfiguration\(this DiGi\.Harness\.Classes\.HarnessConfiguration, string\)\.name') is empty\.

Names compare ordinal, ignoring case. A disabled or incomplete provider is never returned.

```csharp
public static DiGi.Harness.Classes.ProviderConfiguration? ProviderConfiguration(this DiGi.Harness.Classes.HarnessConfiguration? harnessConfiguration, string? name=null);
```
#### Parameters

<a name='DiGi.Harness.Query.ProviderConfiguration(thisDiGi.Harness.Classes.HarnessConfiguration,string).harnessConfiguration'></a>

`harnessConfiguration` [HarnessConfiguration](DiGi.Harness.Classes.md#DiGi.Harness.Classes.HarnessConfiguration 'DiGi\.Harness\.Classes\.HarnessConfiguration')

The configuration\.

<a name='DiGi.Harness.Query.ProviderConfiguration(thisDiGi.Harness.Classes.HarnessConfiguration,string).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The provider name, or null for [DefaultProviderName](DiGi.Harness.Classes.md#DiGi.Harness.Classes.HarnessConfiguration.DefaultProviderName 'DiGi\.Harness\.Classes\.HarnessConfiguration\.DefaultProviderName')\.

#### Returns
[ProviderConfiguration](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ProviderConfiguration 'DiGi\.Harness\.Classes\.ProviderConfiguration')  
The usable provider, or null when none matches\.

<a name='DiGi.Harness.Query.Resolved(thisSystem.Text.Json.Nodes.JsonNode,System.Text.Json.Nodes.JsonObject,int)'></a>

## Query\.Resolved\(this JsonNode, JsonObject, int\) Method

Copies a JSON node from an OpenAPI document with its local `$ref`s \(`#/components/...`\) replaced by the referenced nodes, down to [depth](DiGi.Harness.md#DiGi.Harness.Query.Resolved(thisSystem.Text.Json.Nodes.JsonNode,System.Text.Json.Nodes.JsonObject,int).depth 'DiGi\.Harness\.Query\.Resolved\(this System\.Text\.Json\.Nodes\.JsonNode, System\.Text\.Json\.Nodes\.JsonObject, int\)\.depth') levels of references\.

A reference beyond the depth, or one that cannot be resolved, stays as `{"$ref": ...}`; `example` and `examples` members are dropped to keep the result short.

```csharp
public static System.Text.Json.Nodes.JsonNode? Resolved(this System.Text.Json.Nodes.JsonNode? jsonNode, System.Text.Json.Nodes.JsonObject? swagger, int depth);
```
#### Parameters

<a name='DiGi.Harness.Query.Resolved(thisSystem.Text.Json.Nodes.JsonNode,System.Text.Json.Nodes.JsonObject,int).jsonNode'></a>

`jsonNode` [System\.Text\.Json\.Nodes\.JsonNode](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonnode 'System\.Text\.Json\.Nodes\.JsonNode')

The node to copy\.

<a name='DiGi.Harness.Query.Resolved(thisSystem.Text.Json.Nodes.JsonNode,System.Text.Json.Nodes.JsonObject,int).swagger'></a>

`swagger` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The OpenAPI document the references point into\.

<a name='DiGi.Harness.Query.Resolved(thisSystem.Text.Json.Nodes.JsonNode,System.Text.Json.Nodes.JsonObject,int).depth'></a>

`depth` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

How many levels of references to resolve\.

#### Returns
[System\.Text\.Json\.Nodes\.JsonNode](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonnode 'System\.Text\.Json\.Nodes\.JsonNode')  
The copied node with references resolved, or null when [jsonNode](DiGi.Harness.md#DiGi.Harness.Query.Resolved(thisSystem.Text.Json.Nodes.JsonNode,System.Text.Json.Nodes.JsonObject,int).jsonNode 'DiGi\.Harness\.Query\.Resolved\(this System\.Text\.Json\.Nodes\.JsonNode, System\.Text\.Json\.Nodes\.JsonObject, int\)\.jsonNode') is null\.

<a name='DiGi.Harness.Query.SummaryLine(thisstring,int)'></a>

## Query\.SummaryLine\(this string, int\) Method

Shortens a text to one summary line: its first sentence or first line, cut to [maxCharacters](DiGi.Harness.md#DiGi.Harness.Query.SummaryLine(thisstring,int).maxCharacters 'DiGi\.Harness\.Query\.SummaryLine\(this string, int\)\.maxCharacters') with an ellipsis\.

Markdown emphasis and heading markers at the start are dropped, so a thinking summary such as `**Checking counties**` reads as plain text.

```csharp
public static string? SummaryLine(this string? text, int maxCharacters);
```
#### Parameters

<a name='DiGi.Harness.Query.SummaryLine(thisstring,int).text'></a>

`text` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The text\.

<a name='DiGi.Harness.Query.SummaryLine(thisstring,int).maxCharacters'></a>

`maxCharacters` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The maximum length of the line, ellipsis included; values below 10 use 10\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The summary line, or null when the text is empty\.