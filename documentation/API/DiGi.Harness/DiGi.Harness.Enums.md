#### [DiGi\.Harness](DiGi.Harness.Overview.md 'DiGi\.Harness\.Overview')

## DiGi\.Harness\.Enums Namespace
### Enums

<a name='DiGi.Harness.Enums.ContentKind'></a>

## ContentKind Enum

The kind of content block being accumulated from a stream\.

```csharp
public enum ContentKind
```
### Fields

<a name='DiGi.Harness.Enums.ContentKind.Undefined'></a>

`Undefined` 0

Not set\.

<a name='DiGi.Harness.Enums.ContentKind.Text'></a>

`Text` 1

Answer text\.

<a name='DiGi.Harness.Enums.ContentKind.Thinking'></a>

`Thinking` 2

Thinking or reasoning text\.

<a name='DiGi.Harness.Enums.ContentKind.RedactedThinking'></a>

`RedactedThinking` 3

An Anthropic `redacted_thinking` block\.

<a name='DiGi.Harness.Enums.ContentKind.ToolUse'></a>

`ToolUse` 4

A tool call\.

<a name='DiGi.Harness.Enums.ErrorCategory'></a>

## ErrorCategory Enum

Why a turn did not finish normally\.

```csharp
public enum ErrorCategory
```
### Fields

<a name='DiGi.Harness.Enums.ErrorCategory.Undefined'></a>

`Undefined` 0

No error\.

<a name='DiGi.Harness.Enums.ErrorCategory.Unavailable'></a>

`Unavailable` 1

The provider gave no answer \(unreachable, timed out, or the connection dropped\); the WebAPI equivalent is 503\.

<a name='DiGi.Harness.Enums.ErrorCategory.UpstreamFault'></a>

`UpstreamFault` 2

The provider answered with a failure status or an error event; the WebAPI equivalent is 502\.

<a name='DiGi.Harness.Enums.ErrorCategory.Refusal'></a>

`Refusal` 3

The provider declined the request\.

<a name='DiGi.Harness.Enums.ErrorCategory.MaxTokens'></a>

`MaxTokens` 4

The answer was cut off at the maximum number of output tokens\.

<a name='DiGi.Harness.Enums.ErrorCategory.MaxToolIterations'></a>

`MaxToolIterations` 5

The model kept calling tools beyond the configured iteration limit\.

<a name='DiGi.Harness.Enums.ErrorCategory.InvalidConfiguration'></a>

`InvalidConfiguration` 6

The provider configuration is incomplete \(no base URI, model or protocol\)\.

<a name='DiGi.Harness.Enums.ExportMode'></a>

## ExportMode Enum

How much of a conversation an export contains\.

```csharp
public enum ExportMode
```
### Fields

<a name='DiGi.Harness.Enums.ExportMode.Undefined'></a>

`Undefined` 0

Not set; treated as [Messages](DiGi.Harness.Enums.md#DiGi.Harness.Enums.ExportMode.Messages 'DiGi\.Harness\.Enums\.ExportMode\.Messages')\.

<a name='DiGi.Harness.Enums.ExportMode.Messages'></a>

`Messages` 1

The user and assistant text only\.

<a name='DiGi.Harness.Enums.ExportMode.Full'></a>

`Full` 2

The text, the complete thinking text, the tool calls and the tool results\.

<a name='DiGi.Harness.Enums.Protocol'></a>

## Protocol Enum

The wire protocol used to talk to a model provider\.

```csharp
public enum Protocol
```
### Fields

<a name='DiGi.Harness.Enums.Protocol.Undefined'></a>

`Undefined` 0

The protocol is not set; a provider with this value is not usable\.

<a name='DiGi.Harness.Enums.Protocol.OpenAI'></a>

`OpenAI` 1

The OpenAI Chat Completions protocol \(`POST {BaseUri}/chat/completions`\), used by DeepSeek, Xiaomi MiMo, LM Studio, Strata and other compatible servers\.

<a name='DiGi.Harness.Enums.Protocol.Anthropic'></a>

`Anthropic` 2

The Anthropic Messages protocol \(`POST {BaseUri}/v1/messages`\), used by Anthropic and by Anthropic\-compatible endpoints\.

<a name='DiGi.Harness.Enums.Role'></a>

## Role Enum

The author of a conversation message\.

```csharp
public enum Role
```
### Fields

<a name='DiGi.Harness.Enums.Role.Undefined'></a>

`Undefined` 0

The role is not set\.

<a name='DiGi.Harness.Enums.Role.User'></a>

`User` 1

A message written by the user, or tool results returned on the user's side of the conversation\.

<a name='DiGi.Harness.Enums.Role.Assistant'></a>

`Assistant` 2

A message produced by the model\.

<a name='DiGi.Harness.Enums.StopReason'></a>

## StopReason Enum

Why the model stopped producing output for one request\.

```csharp
public enum StopReason
```
### Fields

<a name='DiGi.Harness.Enums.StopReason.Undefined'></a>

`Undefined` 0

No stop reason was reported\.

<a name='DiGi.Harness.Enums.StopReason.EndTurn'></a>

`EndTurn` 1

The model finished its answer\.

<a name='DiGi.Harness.Enums.StopReason.ToolUse'></a>

`ToolUse` 2

The model stopped to call one or more tools\.

<a name='DiGi.Harness.Enums.StopReason.MaxTokens'></a>

`MaxTokens` 3

The output reached the configured maximum number of tokens\.

<a name='DiGi.Harness.Enums.StopReason.Refusal'></a>

`Refusal` 4

The provider declined the request \(Anthropic `refusal`, OpenAI `content_filter`\)\.

<a name='DiGi.Harness.Enums.StopReason.Other'></a>

`Other` 5

Any other reason reported by the provider\.

<a name='DiGi.Harness.Enums.ThinkingVisibility'></a>

## ThinkingVisibility Enum

How much of the model's thinking a client receives\.

```csharp
public enum ThinkingVisibility
```
### Fields

<a name='DiGi.Harness.Enums.ThinkingVisibility.Undefined'></a>

`Undefined` 0

Not set; treated as [Summary](DiGi.Harness.Enums.md#DiGi.Harness.Enums.ThinkingVisibility.Summary 'DiGi\.Harness\.Enums\.ThinkingVisibility\.Summary')\.

<a name='DiGi.Harness.Enums.ThinkingVisibility.Full'></a>

`Full` 1

Every thinking delta is sent as it arrives\.

<a name='DiGi.Harness.Enums.ThinkingVisibility.Summary'></a>

`Summary` 2

One short line per thinking block is sent once the block is complete\.

<a name='DiGi.Harness.Enums.ThinkingVisibility.None'></a>

`None` 3

No thinking is sent at all\.

<a name='DiGi.Harness.Enums.ToolChoice'></a>

## ToolChoice Enum

Whether the model may call the tools offered in a request\. The tools stay in the request either way: Anthropic rejects a conversation holding tool calls and results when no tools are defined\.

```csharp
public enum ToolChoice
```
### Fields

<a name='DiGi.Harness.Enums.ToolChoice.Undefined'></a>

`Undefined` 0

Not set; treated as [Auto](DiGi.Harness.Enums.md#DiGi.Harness.Enums.ToolChoice.Auto 'DiGi\.Harness\.Enums\.ToolChoice\.Auto')\.

<a name='DiGi.Harness.Enums.ToolChoice.Auto'></a>

`Auto` 1

The model decides whether to call a tool \(`tool_choice: auto`\)\.

<a name='DiGi.Harness.Enums.ToolChoice.None'></a>

`None` 2

The model must answer without calling a tool \(`tool_choice: none`\)\. Some OpenAI\-compatible servers ignore it, so a tool call can still come back\.