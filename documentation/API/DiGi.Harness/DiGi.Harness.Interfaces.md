#### [DiGi\.Harness](DiGi.Harness.Overview.md 'DiGi\.Harness\.Overview')

## DiGi\.Harness\.Interfaces Namespace
### Interfaces

<a name='DiGi.Harness.Interfaces.IContent'></a>

## IContent Interface

Marker interface for one content block of a conversation message \(text, thinking, tool use or tool result\)\.

```csharp
public interface IContent : DiGi.Harness.Interfaces.IHarnessSerializableObject, DiGi.Harness.Interfaces.IHarnessObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Derived  
↳ [TextContent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.TextContent 'DiGi\.Harness\.Classes\.TextContent')  
↳ [ThinkingContent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ThinkingContent 'DiGi\.Harness\.Classes\.ThinkingContent')  
↳ [ToolResultContent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolResultContent 'DiGi\.Harness\.Classes\.ToolResultContent')  
↳ [ToolUseContent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolUseContent 'DiGi\.Harness\.Classes\.ToolUseContent')

Implements [IHarnessSerializableObject](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IHarnessSerializableObject 'DiGi\.Harness\.Interfaces\.IHarnessSerializableObject'), [IHarnessObject](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IHarnessObject 'DiGi\.Harness\.Interfaces\.IHarnessObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')

<a name='DiGi.Harness.Interfaces.IHarnessEvent'></a>

## IHarnessEvent Interface

An event emitted while a turn runs, streamed to the client\.

```csharp
public interface IHarnessEvent : DiGi.Harness.Interfaces.IHarnessSerializableObject, DiGi.Harness.Interfaces.IHarnessObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Derived  
↳ [HarnessEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.HarnessEvent 'DiGi\.Harness\.Classes\.HarnessEvent')

Implements [IHarnessSerializableObject](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IHarnessSerializableObject 'DiGi\.Harness\.Interfaces\.IHarnessSerializableObject'), [IHarnessObject](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IHarnessObject 'DiGi\.Harness\.Interfaces\.IHarnessObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Properties

<a name='DiGi.Harness.Interfaces.IHarnessEvent.ElapsedMilliseconds'></a>

## IHarnessEvent\.ElapsedMilliseconds Property

Gets the time elapsed since the turn started, in milliseconds\.

```csharp
double ElapsedMilliseconds { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Harness.Interfaces.IHarnessObject'></a>

## IHarnessObject Interface

Marker interface for all objects belonging to the DiGi\.Harness project\.

```csharp
public interface IHarnessObject : DiGi.Core.Interfaces.IObject
```

Derived  
↳ [CallEndpointTool](DiGi.Harness.Classes.md#DiGi.Harness.Classes.CallEndpointTool 'DiGi\.Harness\.Classes\.CallEndpointTool')  
↳ [CompletionResult](DiGi.Harness.Classes.md#DiGi.Harness.Classes.CompletionResult 'DiGi\.Harness\.Classes\.CompletionResult')  
↳ [CompletionState](DiGi.Harness.Classes.md#DiGi.Harness.Classes.CompletionState 'DiGi\.Harness\.Classes\.CompletionState')  
↳ [ContentState](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ContentState 'DiGi\.Harness\.Classes\.ContentState')  
↳ [Conversation](DiGi.Harness.Classes.md#DiGi.Harness.Classes.Conversation 'DiGi\.Harness\.Classes\.Conversation')  
↳ [ConversationExport](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ConversationExport 'DiGi\.Harness\.Classes\.ConversationExport')  
↳ [DescribeEndpointTool](DiGi.Harness.Classes.md#DiGi.Harness.Classes.DescribeEndpointTool 'DiGi\.Harness\.Classes\.DescribeEndpointTool')  
↳ [HarnessConfiguration](DiGi.Harness.Classes.md#DiGi.Harness.Classes.HarnessConfiguration 'DiGi\.Harness\.Classes\.HarnessConfiguration')  
↳ [HarnessEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.HarnessEvent 'DiGi\.Harness\.Classes\.HarnessEvent')  
↳ [Message](DiGi.Harness.Classes.md#DiGi.Harness.Classes.Message 'DiGi\.Harness\.Classes\.Message')  
↳ [ProviderConfiguration](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ProviderConfiguration 'DiGi\.Harness\.Classes\.ProviderConfiguration')  
↳ [RunOptions](DiGi.Harness.Classes.md#DiGi.Harness.Classes.RunOptions 'DiGi\.Harness\.Classes\.RunOptions')  
↳ [ServerSentEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ServerSentEvent 'DiGi\.Harness\.Classes\.ServerSentEvent')  
↳ [TextContent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.TextContent 'DiGi\.Harness\.Classes\.TextContent')  
↳ [ThinkingContent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ThinkingContent 'DiGi\.Harness\.Classes\.ThinkingContent')  
↳ [ToolDefinition](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolDefinition 'DiGi\.Harness\.Classes\.ToolDefinition')  
↳ [ToolResultContent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolResultContent 'DiGi\.Harness\.Classes\.ToolResultContent')  
↳ [ToolUseContent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolUseContent 'DiGi\.Harness\.Classes\.ToolUseContent')  
↳ [TurnResult](DiGi.Harness.Classes.md#DiGi.Harness.Classes.TurnResult 'DiGi\.Harness\.Classes\.TurnResult')  
↳ [Usage](DiGi.Harness.Classes.md#DiGi.Harness.Classes.Usage 'DiGi\.Harness\.Classes\.Usage')  
↳ [IContent](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IContent 'DiGi\.Harness\.Interfaces\.IContent')  
↳ [IHarnessEvent](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IHarnessEvent 'DiGi\.Harness\.Interfaces\.IHarnessEvent')  
↳ [IHarnessSerializableObject](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IHarnessSerializableObject 'DiGi\.Harness\.Interfaces\.IHarnessSerializableObject')  
↳ [ITool](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.ITool 'DiGi\.Harness\.Interfaces\.ITool')

Implements [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject')

<a name='DiGi.Harness.Interfaces.IHarnessSerializableObject'></a>

## IHarnessSerializableObject Interface

Marker interface for all serializable objects belonging to the DiGi\.Harness project\.

```csharp
public interface IHarnessSerializableObject : DiGi.Harness.Interfaces.IHarnessObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Derived  
↳ [Conversation](DiGi.Harness.Classes.md#DiGi.Harness.Classes.Conversation 'DiGi\.Harness\.Classes\.Conversation')  
↳ [ConversationExport](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ConversationExport 'DiGi\.Harness\.Classes\.ConversationExport')  
↳ [HarnessConfiguration](DiGi.Harness.Classes.md#DiGi.Harness.Classes.HarnessConfiguration 'DiGi\.Harness\.Classes\.HarnessConfiguration')  
↳ [HarnessEvent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.HarnessEvent 'DiGi\.Harness\.Classes\.HarnessEvent')  
↳ [Message](DiGi.Harness.Classes.md#DiGi.Harness.Classes.Message 'DiGi\.Harness\.Classes\.Message')  
↳ [ProviderConfiguration](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ProviderConfiguration 'DiGi\.Harness\.Classes\.ProviderConfiguration')  
↳ [RunOptions](DiGi.Harness.Classes.md#DiGi.Harness.Classes.RunOptions 'DiGi\.Harness\.Classes\.RunOptions')  
↳ [TextContent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.TextContent 'DiGi\.Harness\.Classes\.TextContent')  
↳ [ThinkingContent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ThinkingContent 'DiGi\.Harness\.Classes\.ThinkingContent')  
↳ [ToolDefinition](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolDefinition 'DiGi\.Harness\.Classes\.ToolDefinition')  
↳ [ToolResultContent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolResultContent 'DiGi\.Harness\.Classes\.ToolResultContent')  
↳ [ToolUseContent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolUseContent 'DiGi\.Harness\.Classes\.ToolUseContent')  
↳ [TurnResult](DiGi.Harness.Classes.md#DiGi.Harness.Classes.TurnResult 'DiGi\.Harness\.Classes\.TurnResult')  
↳ [Usage](DiGi.Harness.Classes.md#DiGi.Harness.Classes.Usage 'DiGi\.Harness\.Classes\.Usage')  
↳ [IContent](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IContent 'DiGi\.Harness\.Interfaces\.IContent')  
↳ [IHarnessEvent](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IHarnessEvent 'DiGi\.Harness\.Interfaces\.IHarnessEvent')

Implements [IHarnessObject](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IHarnessObject 'DiGi\.Harness\.Interfaces\.IHarnessObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')

<a name='DiGi.Harness.Interfaces.ITool'></a>

## ITool Interface

A tool the model can call during a turn\.

```csharp
public interface ITool : DiGi.Harness.Interfaces.IHarnessObject, DiGi.Core.Interfaces.IObject
```

Derived  
↳ [CallEndpointTool](DiGi.Harness.Classes.md#DiGi.Harness.Classes.CallEndpointTool 'DiGi\.Harness\.Classes\.CallEndpointTool')  
↳ [DescribeEndpointTool](DiGi.Harness.Classes.md#DiGi.Harness.Classes.DescribeEndpointTool 'DiGi\.Harness\.Classes\.DescribeEndpointTool')

Implements [IHarnessObject](DiGi.Harness.Interfaces.md#DiGi.Harness.Interfaces.IHarnessObject 'DiGi\.Harness\.Interfaces\.IHarnessObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject')
### Properties

<a name='DiGi.Harness.Interfaces.ITool.ToolDefinition'></a>

## ITool\.ToolDefinition Property

Gets the definition sent to the model: the name, description and JSON input schema\.

```csharp
DiGi.Harness.Classes.ToolDefinition ToolDefinition { get; }
```

#### Property Value
[ToolDefinition](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolDefinition 'DiGi\.Harness\.Classes\.ToolDefinition')
### Methods

<a name='DiGi.Harness.Interfaces.ITool.InvokeAsync(DiGi.Harness.Classes.ToolUseContent,System.Threading.CancellationToken)'></a>

## ITool\.InvokeAsync\(ToolUseContent, CancellationToken\) Method

Runs the tool for one call made by the model\.

A failure the model should see is returned as a result with [IsError](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolResultContent.IsError 'DiGi\.Harness\.Classes\.ToolResultContent\.IsError') set, never thrown; only a requested cancellation is rethrown.

```csharp
System.Threading.Tasks.Task<DiGi.Harness.Classes.ToolResultContent> InvokeAsync(DiGi.Harness.Classes.ToolUseContent toolUseContent, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.Harness.Interfaces.ITool.InvokeAsync(DiGi.Harness.Classes.ToolUseContent,System.Threading.CancellationToken).toolUseContent'></a>

`toolUseContent` [ToolUseContent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolUseContent 'DiGi\.Harness\.Classes\.ToolUseContent')

The call made by the model, including its input\.

<a name='DiGi.Harness.Interfaces.ITool.InvokeAsync(DiGi.Harness.Classes.ToolUseContent,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token that cancels the call\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ToolResultContent](DiGi.Harness.Classes.md#DiGi.Harness.Classes.ToolResultContent 'DiGi\.Harness\.Classes\.ToolResultContent')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The result returned to the model\.