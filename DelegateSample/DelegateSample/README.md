## .Net Framework的编码规范
- 委托类型的名称都应该以EventHandler结束。
- 委托的原型定义：有一个void返回值，并接受两个输入参数：一个Object 类型，一个 EventArgs类型(或继承自EventArgs)。
- 事件的命名为 委托去掉 EventHandler之后剩余的部分。
- 继承自EventArgs的类型应该以EventArgs结尾
