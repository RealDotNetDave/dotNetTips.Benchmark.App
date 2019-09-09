``` ini

BenchmarkDotNet=v0.11.5.1161-nightly, OS=Windows 10.0.17763.678 (1809/October2018Update/Redstone5)
Unknown processor
.NET Core SDK=3.0.100-preview8-013656
  [Host]     : .NET Core 3.0.0 (CoreCLR 4.700.19.37902, CoreFX 4.700.19.40503), X64 RyuJIT
  Job-ITKQKJ : .NET Core 2.2.0 (CoreCLR 4.6.27110.04, CoreFX 4.6.27110.04), X64 RyuJIT
  Job-VHFKBN : .NET Core 3.0.0 (CoreCLR 4.700.19.37902, CoreFX 4.700.19.40503), X64 RyuJIT
  Job-DECCFI : .NET Framework 4.8 (4.8.3801.0), X64 RyuJIT
  Job-RXKYBM : .NET Framework 4.8 (4.8.3801.0), X64 RyuJIT

EvaluateOverhead=True  Server=True  

```
|                                               Method |     Toolchain |           Mean |       Error |      StdDev | Rank |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------------------------------------- |-------------- |---------------:|------------:|------------:|-----:|-------:|-------:|------:|----------:|
|                   **&#39;COMBINE STRINGS:2 Strings with +&#39;** | **.NET Core 2.2** |     **21.3385 ns** |   **0.1550 ns** |   **0.1450 ns** |   **17** | **0.0063** |      **-** |     **-** |     **128 B** |
|                   &#39;COMBINE STRINGS:2 Strings with +&#39; | .NET Core 3.0 |     21.5285 ns |   0.0510 ns |   0.0477 ns |   17 | 0.0134 |      - |     - |     128 B |
|                   &#39;COMBINE STRINGS:2 Strings with +&#39; |        net472 |     17.4502 ns |   0.1810 ns |   0.1693 ns |   15 | 0.0612 |      - |     - |     128 B |
|                   &#39;COMBINE STRINGS:2 Strings with +&#39; |         net48 |     17.4204 ns |   0.0314 ns |   0.0293 ns |   15 | 0.0612 |      - |     - |     128 B |
|     **&#39;COMBINE STRINGS:2 strings with string.Concat()&#39;** | **.NET Core 2.2** |     **22.6078 ns** |   **0.0784 ns** |   **0.0733 ns** |   **18** | **0.0062** |      **-** |     **-** |     **128 B** |
|     &#39;COMBINE STRINGS:2 strings with string.Concat()&#39; | .NET Core 3.0 |     22.4144 ns |   0.0831 ns |   0.0694 ns |   18 | 0.0134 |      - |     - |     128 B |
|     &#39;COMBINE STRINGS:2 strings with string.Concat()&#39; |        net472 |     19.9203 ns |   0.0436 ns |   0.0364 ns |   16 | 0.0612 |      - |     - |     128 B |
|     &#39;COMBINE STRINGS:2 strings with string.Concat()&#39; |         net48 |     17.3739 ns |   0.0522 ns |   0.0436 ns |   15 | 0.0612 |      - |     - |     128 B |
|                     **&#39;DECODING STRING:Encoding.UTF32&#39;** | **.NET Core 2.2** | **15,769.0277 ns** |  **16.1632 ns** |  **14.3283 ns** |   **37** | **0.0610** |      **-** |     **-** |    **2096 B** |
|                     &#39;DECODING STRING:Encoding.UTF32&#39; | .NET Core 3.0 | 15,454.3048 ns |  57.2227 ns |  53.5262 ns |   36 | 0.2136 |      - |     - |    2144 B |
|                     &#39;DECODING STRING:Encoding.UTF32&#39; |        net472 | 15,574.7807 ns |  20.1826 ns |  17.8913 ns |   36 | 0.9766 |      - |     - |    2103 B |
|                     &#39;DECODING STRING:Encoding.UTF32&#39; |         net48 | 15,560.7474 ns |   9.6578 ns |   8.0647 ns |   36 | 0.9918 |      - |     - |    2103 B |
|                      **&#39;DECODING STRING:Encoding.UTF7&#39;** | **.NET Core 2.2** |  **7,467.8024 ns** |  **68.8045 ns** |  **60.9934 ns** |   **31** | **0.0916** |      **-** |     **-** |    **2288 B** |
|                      &#39;DECODING STRING:Encoding.UTF7&#39; | .NET Core 3.0 |  8,579.3968 ns |  32.7678 ns |  30.6511 ns |   34 | 0.2441 |      - |     - |    2320 B |
|                      &#39;DECODING STRING:Encoding.UTF7&#39; |        net472 |  7,920.9096 ns |  84.5409 ns |  79.0796 ns |   32 | 1.0834 |      - |     - |    2296 B |
|                      &#39;DECODING STRING:Encoding.UTF7&#39; |         net48 |  7,752.0123 ns |  11.3630 ns |  10.6290 ns |   32 | 1.0834 |      - |     - |    2296 B |
|            **&#39;EMPTY STRING VALIDATION:IsNullOrEmpty()&#39;** | **.NET Core 2.2** |      **0.5142 ns** |   **0.0060 ns** |   **0.0056 ns** |    **4** |      **-** |      **-** |     **-** |         **-** |
|            &#39;EMPTY STRING VALIDATION:IsNullOrEmpty()&#39; | .NET Core 3.0 |      0.3141 ns |   0.0060 ns |   0.0056 ns |    3 |      - |      - |     - |         - |
|            &#39;EMPTY STRING VALIDATION:IsNullOrEmpty()&#39; |        net472 |      0.2690 ns |   0.0339 ns |   0.0318 ns |    1 |      - |      - |     - |         - |
|            &#39;EMPTY STRING VALIDATION:IsNullOrEmpty()&#39; |         net48 |      0.3010 ns |   0.0071 ns |   0.0066 ns |    2 |      - |      - |     - |         - |
|       **&#39;EMPTY STRING VALIDATION:IsNullOrWhitespace()&#39;** | **.NET Core 2.2** |      **2.0813 ns** |   **0.0249 ns** |   **0.0233 ns** |    **5** |      **-** |      **-** |     **-** |         **-** |
|       &#39;EMPTY STRING VALIDATION:IsNullOrWhitespace()&#39; | .NET Core 3.0 |      2.4585 ns |   0.0285 ns |   0.0267 ns |    7 |      - |      - |     - |         - |
|       &#39;EMPTY STRING VALIDATION:IsNullOrWhitespace()&#39; |        net472 |      2.7222 ns |   0.0656 ns |   0.0613 ns |   10 |      - |      - |     - |         - |
|       &#39;EMPTY STRING VALIDATION:IsNullOrWhitespace()&#39; |         net48 |      2.6538 ns |   0.0083 ns |   0.0078 ns |   10 |      - |      - |     - |         - |
|                     **&#39;ENCODING STRING:Encoding.UTF32&#39;** | **.NET Core 2.2** |  **7,823.7376 ns** |  **78.2184 ns** |  **73.1656 ns** |   **32** | **0.1678** |      **-** |     **-** |    **4168 B** |
|                     &#39;ENCODING STRING:Encoding.UTF32&#39; | .NET Core 3.0 |  8,364.4439 ns |  51.7889 ns |  48.4434 ns |   33 | 0.4425 |      - |     - |    4200 B |
|                     &#39;ENCODING STRING:Encoding.UTF32&#39; |        net472 |  7,877.4172 ns |  23.7706 ns |  19.8496 ns |   32 | 1.9836 |      - |     - |    4186 B |
|                     &#39;ENCODING STRING:Encoding.UTF32&#39; |         net48 |  7,889.3058 ns |  10.3933 ns |   9.7219 ns |   32 | 1.9836 |      - |     - |    4186 B |
|                      **&#39;ENCODING STRING:Encoding.UTF7&#39;** | **.NET Core 2.2** | **15,407.2902 ns** |  **26.1613 ns** |  **24.4713 ns** |   **36** | **0.0305** |      **-** |     **-** |    **1360 B** |
|                      &#39;ENCODING STRING:Encoding.UTF7&#39; | .NET Core 3.0 | 18,693.1755 ns |  60.2560 ns |  56.3635 ns |   40 | 0.1221 |      - |     - |    1392 B |
|                      &#39;ENCODING STRING:Encoding.UTF7&#39; |        net472 | 16,396.9881 ns |  42.0272 ns |  39.3122 ns |   39 | 0.6409 |      - |     - |    1364 B |
|                      &#39;ENCODING STRING:Encoding.UTF7&#39; |         net48 | 15,978.1311 ns |  60.2284 ns |  50.2934 ns |   38 | 0.6409 |      - |     - |    1364 B |
|                               **&#39;STRING VALIDATION:==&#39;** | **.NET Core 2.2** |      **4.0111 ns** |   **0.0138 ns** |   **0.0122 ns** |   **13** |      **-** |      **-** |     **-** |         **-** |
|                               &#39;STRING VALIDATION:==&#39; | .NET Core 3.0 |      4.1467 ns |   0.0384 ns |   0.0360 ns |   14 |      - |      - |     - |         - |
|                               &#39;STRING VALIDATION:==&#39; |        net472 |      2.5570 ns |   0.0028 ns |   0.0023 ns |    9 |      - |      - |     - |         - |
|                               &#39;STRING VALIDATION:==&#39; |         net48 |      2.5481 ns |   0.0014 ns |   0.0013 ns |    9 |      - |      - |     - |         - |
|                         **&#39;STRING VALIDATION:Equals()&#39;** | **.NET Core 2.2** |      **3.5095 ns** |   **0.0328 ns** |   **0.0306 ns** |   **12** |      **-** |      **-** |     **-** |         **-** |
|                         &#39;STRING VALIDATION:Equals()&#39; | .NET Core 3.0 |      3.3134 ns |   0.0224 ns |   0.0210 ns |   11 |      - |      - |     - |         - |
|                         &#39;STRING VALIDATION:Equals()&#39; |        net472 |      2.5054 ns |   0.0014 ns |   0.0011 ns |    8 |      - |      - |     - |         - |
|                         &#39;STRING VALIDATION:Equals()&#39; |         net48 |      2.4090 ns |   0.0012 ns |   0.0010 ns |    6 |      - |      - |     - |         - |
| **&#39;STRING VALIDATION:Equals(CurrentCultureIgnoreCase)&#39;** | **.NET Core 2.2** |     **80.4732 ns** |   **0.3479 ns** |   **0.2905 ns** |   **22** |      **-** |      **-** |     **-** |         **-** |
| &#39;STRING VALIDATION:Equals(CurrentCultureIgnoreCase)&#39; | .NET Core 3.0 |     51.2711 ns |   0.6996 ns |   0.6202 ns |   19 |      - |      - |     - |         - |
| &#39;STRING VALIDATION:Equals(CurrentCultureIgnoreCase)&#39; |        net472 |     71.0586 ns |   0.1891 ns |   0.1769 ns |   21 |      - |      - |     - |         - |
| &#39;STRING VALIDATION:Equals(CurrentCultureIgnoreCase)&#39; |         net48 |     70.0262 ns |   0.2937 ns |   0.2747 ns |   20 |      - |      - |     - |         - |
|                               **STRINGBUILDER:Append()** | **.NET Core 2.2** |  **2,065.2096 ns** |   **5.2606 ns** |   **4.9208 ns** |   **26** | **0.6599** | **0.0114** |     **-** |   **13872 B** |
|                               STRINGBUILDER:Append() | .NET Core 3.0 |  2,088.0319 ns |  13.8286 ns |  12.9353 ns |   26 | 1.4534 | 0.0343 |     - |   13864 B |
|                               STRINGBUILDER:Append() |        net472 |  1,680.6419 ns |  11.7812 ns |  11.0201 ns |   24 | 6.6223 |      - |     - |   13922 B |
|                               STRINGBUILDER:Append() |         net48 |  1,604.1819 ns |   2.5298 ns |   2.2426 ns |   23 | 6.6223 |      - |     - |   13916 B |
|                         **STRINGBUILDER:AppendFormat()** | **.NET Core 2.2** |  **7,811.4632 ns** |  **34.9163 ns** |  **30.9524 ns** |   **32** | **0.6409** |      **-** |     **-** |   **15272 B** |
|                         STRINGBUILDER:AppendFormat() | .NET Core 3.0 |  7,085.8230 ns | 136.9038 ns | 140.5901 ns |   30 | 1.6022 | 0.0305 |     - |   15264 B |
|                         STRINGBUILDER:AppendFormat() |        net472 |  5,263.6382 ns |  70.1327 ns |  65.6021 ns |   29 | 7.2937 |      - |     - |   15323 B |
|                         STRINGBUILDER:AppendFormat() |         net48 |  5,242.5856 ns |   8.0858 ns |   7.1678 ns |   29 | 7.2937 |      - |     - |   15323 B |
|           **STRINGBUILDER:AppendFormat(CurrentCulture)** | **.NET Core 2.2** |  **9,849.6741 ns** |  **28.3412 ns** |  **26.5104 ns** |   **35** | **0.6561** |      **-** |     **-** |   **15272 B** |
|           STRINGBUILDER:AppendFormat(CurrentCulture) | .NET Core 3.0 |  8,268.6767 ns |  24.8696 ns |  23.2631 ns |   33 | 1.6022 | 0.0305 |     - |   15264 B |
|           STRINGBUILDER:AppendFormat(CurrentCulture) |        net472 |  7,033.1922 ns |   3.3274 ns |   2.7785 ns |   30 | 7.2937 |      - |     - |   15323 B |
|           STRINGBUILDER:AppendFormat(CurrentCulture) |         net48 |  7,062.4557 ns |  18.2550 ns |  16.1825 ns |   30 | 7.2937 |      - |     - |   15323 B |
|                           **STRINGBUILDER:AppendLine()** | **.NET Core 2.2** |  **2,500.5938 ns** |   **5.9910 ns** |   **5.0027 ns** |   **27** | **0.6981** | **0.0153** |     **-** |   **14272 B** |
|                           STRINGBUILDER:AppendLine() | .NET Core 3.0 |  2,571.0325 ns |  21.7779 ns |  20.3710 ns |   28 | 1.4992 | 0.0381 |     - |   14264 B |
|                           STRINGBUILDER:AppendLine() |        net472 |  2,092.7512 ns |  15.4851 ns |  14.4847 ns |   26 | 6.8169 |      - |     - |   14323 B |
|                           STRINGBUILDER:AppendLine() |         net48 |  2,010.4096 ns |   2.5718 ns |   2.2798 ns |   25 | 6.8169 |      - |     - |   14323 B |
