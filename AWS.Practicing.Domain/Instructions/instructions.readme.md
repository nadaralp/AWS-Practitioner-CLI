# Explanation on how to use instructions.

## General guidelines:

1. Don't use numeric KEYs, or single letter keys (e.g: a, b) because they are saved for dynamically invoked cases.
2. Leave Options empty if you want to have a Dynamic invoker and give a full path on OptionsDynamicExecutorFullPath field
3. You have to provide: DynamicReplyParams on dynamic options to know how to invoke executions with which params. 
You can't provide a different param if not specified, exception will be thrown