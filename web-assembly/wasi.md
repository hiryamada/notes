# WASI (WebAssembly System Interface)

https://github.com/WebAssembly/WASI

a set of portable, modular, runtime-independent, and WebAssembly-native APIs which can be used by WebAssembly code to interact with the outside world.

- APIセット
- WebAssemblyコードから利用できる
- 外界と相互作用できる

https://www.publickey1.jp/blog/19/webassemblywebwasimozillanodejs.html

> （2019/4～）Mozillaは、WebAssemblyにファイルやネットワーク、メモリなどのシステムリソースへ安全にアクセス可能にするAPIの標準仕様「WASI」（WebAssembly System Interface：動画では「ワズィ」と発音しているように聞こえます）の策定を開始

# 実装

- Lucet (2019/4～) -> Wasmtime
- [Wasmer](https://wasmer.io/)
- [Wasmtime](https://wasmtime.dev/)
- [WasmEdge](https://github.com/WasmEdge/WasmEdge)
- [Krustlet](https://github.com/krustlet/krustlet): Kubernetes Kubelet in Rust for running WASM

わかりやすいまとめ
https://zenn.dev/zaki_yama/scraps/cd40f7535b3224
