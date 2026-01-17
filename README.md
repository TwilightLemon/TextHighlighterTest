# TextHighlighter - WPF 文本高亮控件

一个基于 HLSL 着色器的 WPF 文本高亮控件，支持动态高光效果和多种渲染模式。

![效果展示](/Assets/screenshot.png)

## ✨ 特点

- 🎨 **HLSL 着色器渲染** - 使用 GPU 加速的像素着色器实现高性能高光效果
- 🔀 **双重混合模式** - 支持 Additive（加法高光）和 Lerp（插值渐变）两种混合模式
- 📊 **可调节参数** - 高光位置、宽度、强度、颜色均可动态调整
- 🎬 **动画友好** - 所有参数支持 WPF 动画系统，可轻松制作流畅的高光动画
- 📝 **完整文本支持** - 支持文本换行、对齐、裁剪等标准 TextBlock 功能

## 📖 属性说明

### 文本属性

| 属性 | 类型 | 默认值 | 说明 |
|-----|------|--------|------|
| `Text` | `string` | `string.Empty` | 显示的文本内容 |
| `TextWrapping` | `TextWrapping` | `NoWrap` | 文本换行模式 |
| `TextAlignment` | `TextAlignment` | `Left` | 文本对齐方式 |
| `TextTrimming` | `TextTrimming` | `None` | 文本裁剪模式 |
| `LineHeight` | `double` | `NaN` | 行高 |

### 高光属性

| 属性 | 类型 | 默认值 | 说明 |
|-----|------|--------|------|
| `HighlightPos` | `double` | `0.0` | 高光中心位置 (0.0~1.0，允许动画越界) |
| `HighlightWidth` | `double` | `0.4` | 高光宽度 (0.0~1.0) |
| `HighlightColor` | `Color` | `#F0E6F2FF` | 高光颜色 |
| `HighlightIntensity` | `double` | `1.0` | 高光强度 (0.0~1.0) |
| `UseAdditive` | `bool` | `true` | 使用加法混合模式（true）或插值混合模式（false） |

### 标准 WPF 属性

控件继承自 `UserControl`，支持所有标准属性：
- `FontFamily`、`FontSize`、`FontWeight`、`FontStyle`、`FontStretch`
- `Foreground`（文本基础颜色）
- `Margin`、`Padding`、`HorizontalAlignment`、`VerticalAlignment`
- 等...

## 🎨 使用示例

### 示例 1：加法高光模式（Additive）

适合制作发光、闪烁等效果：

```xml
<local:HighlightTextBlock 
    Text="发光文本效果"
    FontSize="48"
    Foreground="#80FFFFFF"
    HighlightColor="#FFFFFF"
    HighlightPos="0.5"
    HighlightWidth="0.3"
    UseAdditive="true" />
```

### 示例 2：插值渐变模式（Lerp）

适合制作颜色渐变、波浪等效果：

```xml
<local:HighlightTextBlock 
    Text="渐变文本效果"
    FontSize="48"
    Foreground="#808080"
    HighlightColor="#FFD700"
    HighlightPos="0.5"
    HighlightWidth="0.5"
    UseAdditive="false" />
```

### 示例 3：多行文本

```xml
<local:HighlightTextBlock 
    Text="这是一段很长的文本，会自动换行显示。支持所有标准的文本属性，包括对齐、裁剪等功能。"
    TextWrapping="Wrap"
    TextAlignment="Center"
    TextTrimming="CharacterEllipsis"
    FontSize="24"
    Foreground="#5EFFFFFF"
    HighlightColor="#66FFFFFF" />
```

## 🛠️ 技术实现

### 核心组件

- **HighlightTextBlock.xaml.cs** - 主控件类，管理文本渲染和属性绑定
- **ProgresiveHighlightEffect.cs** - HLSL 着色器效果包装类
- **TextGlow.ps** - 编译后的像素着色器文件（HLSL）

### 工作原理

1. 使用 `FormattedText` 生成文本几何
2. 将文本形状应用为矩形的裁剪区域
3. 通过 HLSL 像素着色器对裁剪区域应用高光效果
4. 支持两种混合模式：
   - **Additive**：高光颜色叠加到原色上，产生发光效果
   - **Lerp**：在原色和高光颜色之间插值，产生渐变效果

## 📋 系统要求

- .NET Desktop Runtime
- Windows 操作系统
- 支持 Shader Model 3.0 的显卡 （Remote Desktop不支持）

## 📄 许可证

MIT 许可证。详情请参阅 [LICENSE](LICENSE.txt) 文件。
