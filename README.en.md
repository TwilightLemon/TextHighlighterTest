# TextHighlighter - WPF Text Highlight Control

A WPF text highlight control based on HLSL shader, supporting dynamic highlight effects and multiple rendering modes.

![Screenshot](/Assets/screenshot.png)

## ✨ Features

- 🎨 **HLSL Shader Rendering** - High-performance highlight effects using GPU-accelerated pixel shaders
- 🔀 **Dual Blending Modes** - Supports both Additive (glow) and Lerp (gradient interpolation) blending modes
- 📊 **Adjustable Parameters** - Dynamically adjust highlight position, width, intensity, and color
- 🎬 **Animation Friendly** - All parameters support WPF animation system for smooth highlight animations
- 📝 **Full Text Support** - Supports text wrapping, alignment, trimming, and other standard TextBlock features

## 📖 Properties

### Text Properties

| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `Text` | `string` | `string.Empty` | Text content to display |
| `TextWrapping` | `TextWrapping` | `NoWrap` | Text wrapping mode |
| `TextAlignment` | `TextAlignment` | `Left` | Text alignment |
| `TextTrimming` | `TextTrimming` | `None` | Text trimming mode |
| `LineHeight` | `double` | `NaN` | Line height |

### Highlight Properties

| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `HighlightPos` | `double` | `0.0` | Highlight center position (0.0~1.0, can exceed for animation) |
| `HighlightWidth` | `double` | `0.4` | Highlight width (0.0~1.0) |
| `HighlightColor` | `Color` | `#F0E6F2FF` | Highlight color |
| `HighlightIntensity` | `double` | `1.0` | Highlight intensity (0.0~1.0) |
| `UseAdditive` | `bool` | `true` | Use additive blending mode (true) or lerp blending mode (false) |

### Standard WPF Properties

The control inherits from `UserControl` and supports all standard properties:
- `FontFamily`, `FontSize`, `FontWeight`, `FontStyle`, `FontStretch`
- `Foreground` (base text color)
- `Margin`, `Padding`, `HorizontalAlignment`, `VerticalAlignment`
- etc...

## 🎨 Usage Examples

### Example 1: Additive Highlight Mode

Perfect for glow and shimmer effects:

```xml
<local:HighlightTextBlock 
    Text="Glowing Text Effect"
    FontSize="48"
    Foreground="#80FFFFFF"
    HighlightColor="#FFFFFF"
    HighlightPos="0.5"
    HighlightWidth="0.3"
    UseAdditive="true" />
```

### Example 2: Lerp Gradient Mode

Perfect for color gradient and wave effects:

```xml
<local:HighlightTextBlock 
    Text="Gradient Text Effect"
    FontSize="48"
    Foreground="#808080"
    HighlightColor="#FFD700"
    HighlightPos="0.5"
    HighlightWidth="0.5"
    UseAdditive="false" />
```

### Example 3: Multi-line Text

```xml
<local:HighlightTextBlock 
    Text="This is a long text that will wrap automatically. Supports all standard text properties including alignment, trimming, and more."
    TextWrapping="Wrap"
    TextAlignment="Center"
    TextTrimming="CharacterEllipsis"
    FontSize="24"
    Foreground="#5EFFFFFF"
    HighlightColor="#66FFFFFF" />
```

## 🛠️ Technical Implementation

### Core Components

- **HighlightTextBlock.xaml.cs** - Main control class managing text rendering and property binding
- **ProgresiveHighlightEffect.cs** - HLSL shader effect wrapper class
- **TextGlow.ps** - Compiled pixel shader file (HLSL)

### How It Works

1. Generate text geometry using `FormattedText`
2. Apply text shape as clipping region to a rectangle
3. Apply highlight effect to the clipped region via HLSL pixel shader
4. Supports two blending modes:
   - **Additive**: Highlight color is added to the original color, producing a glow effect
   - **Lerp**: Interpolates between original color and highlight color, producing a gradient effect

## 📋 System Requirements

- .NET Desktop Runtime
- Windows operating system
- Graphics card supporting Shader Model 3.0 (Not supported in Remote Desktop)

## 📄 License

MIT License. See [LICENSE](LICENSE.txt) file for details.
