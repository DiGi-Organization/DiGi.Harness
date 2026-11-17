#### [DiGi\.Harness](DiGi.Harness.Overview.md 'DiGi\.Harness\.Overview')

## DiGi\.Harness\.Constants Namespace
### Classes

<a name='DiGi.Harness.Constants.Anthropic'></a>

## Anthropic Class

Wire constants of the Anthropic Messages protocol\.

```csharp
public static class Anthropic
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Anthropic
### Fields

<a name='DiGi.Harness.Constants.Anthropic.FallbackBeta'></a>

## Anthropic\.FallbackBeta Field

The beta flag enabling server\-side refusal fallbacks \(`fallbacks: "default"`\)\.

```csharp
public const string FallbackBeta = "server-side-fallback-2026-07-01";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Constants.Anthropic.MessagesPath'></a>

## Anthropic\.MessagesPath Field

The relative path of the Messages endpoint, appended to the provider base URI\.

```csharp
public const string MessagesPath = "v1/messages";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Constants.Anthropic.Version'></a>

## Anthropic\.Version Field

The value of the `anthropic-version` header\.

```csharp
public const string Version = "2023-06-01";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Constants.Default'></a>

## Default Class

Default limits used when the configuration does not set them\.

```csharp
public static class Default
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Default
### Fields

<a name='DiGi.Harness.Constants.Default.MaxErrorCharacters'></a>

## Default\.MaxErrorCharacters Field

The maximum number of characters of an upstream error body quoted in an error message\.

```csharp
public const int MaxErrorCharacters = 500;
```

#### Field Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.Harness.Constants.Default.MaxSummaryCharacters'></a>

## Default\.MaxSummaryCharacters Field

The maximum number of characters of an operation summary in the OpenAPI index\.

```csharp
public const int MaxSummaryCharacters = 160;
```

#### Field Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.Harness.Constants.Default.MaxTokens'></a>

## Default\.MaxTokens Field

The default maximum number of output tokens of one model request\.

```csharp
public const int MaxTokens = 16000;
```

#### Field Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.Harness.Constants.Default.MaxToolIterations'></a>

## Default\.MaxToolIterations Field

The default maximum number of model requests in one turn\.

```csharp
public const int MaxToolIterations = 12;
```

#### Field Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.Harness.Constants.Default.MaxToolResultCharacters'></a>

## Default\.MaxToolResultCharacters Field

The default maximum number of characters of one tool result returned to the model\.

```csharp
public const int MaxToolResultCharacters = 20000;
```

#### Field Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.Harness.Constants.Default.RequestTimeoutSeconds'></a>

## Default\.RequestTimeoutSeconds Field

The default timeout of one model request, in seconds\.

```csharp
public const int RequestTimeoutSeconds = 300;
```

#### Field Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.Harness.Constants.FileName'></a>

## FileName Class

File names used by DiGi\.Harness\.

```csharp
public static class FileName
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → FileName
### Fields

<a name='DiGi.Harness.Constants.FileName.Harness'></a>

## FileName\.Harness Field

The JSON configuration file holding the providers and limits; the real one, with keys, belongs in `user files/`\.

```csharp
public const string Harness = "Harness.json";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Constants.OpenAI'></a>

## OpenAI Class

Wire constants of the OpenAI Chat Completions protocol\.

```csharp
public static class OpenAI
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → OpenAI
### Fields

<a name='DiGi.Harness.Constants.OpenAI.ChatCompletionsPath'></a>

## OpenAI\.ChatCompletionsPath Field

The relative path of the Chat Completions endpoint, appended to the provider base URI \(which normally ends in `/v1`\)\.

```csharp
public const string ChatCompletionsPath = "chat/completions";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Constants.OpenAI.Done'></a>

## OpenAI\.Done Field

The data line that ends an OpenAI stream\.

```csharp
public const string Done = "[DONE]";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Constants.ToolName'></a>

## ToolName Class

Names of the tools shipped with DiGi\.Harness\.

```csharp
public static class ToolName
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ToolName
### Fields

<a name='DiGi.Harness.Constants.ToolName.CallEndpoint'></a>

## ToolName\.CallEndpoint Field

The tool calling one WebAPI operation\.

```csharp
public const string CallEndpoint = "call_endpoint";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Harness.Constants.ToolName.DescribeEndpoint'></a>

## ToolName\.DescribeEndpoint Field

The tool returning one WebAPI operation's parameters and schemas\.

```csharp
public const string DescribeEndpoint = "describe_endpoint";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')