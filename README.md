# ８番シアター（Exit8Like）

学校のチーム制作で取り組んだ、8番出口ライクの2Dアドベンチャーゲームです。  
プレイヤーはAとDで左右に移動し、*異変*が発生していないときに進み、異変があれば戻るというシンプルなルールで、**8回正しく判断するとクリア**となります。

## 🎮 ゲームルール
- Aキー / Dキーで左右に移動
- 進むたびにマップがループ
- マップに*異変*（見た目の違和感）があれば戻る、なければ進む
- 異変に気づかず進むとゲームオーバー
- 8回正解するとクリア

## 担当箇所（矢萩 / Allow-hub）
- 異変ギミックの約半分を実装
- ゲーム全体のステート管理（GameManager）  
  [GameManager.cs](https://github.com/Allow-hub/Exit8Like/blob/main/Assets/Scripts/GameManager.cs)
- プレイヤー周りの処理  
  [Player Scripts](https://github.com/Allow-hub/Exit8Like/tree/main/Assets/Scripts/InGame/Player)

## 工夫・挑戦したこと
- **初めて継承を活用し、異変ギミックを共通の基底クラスで扱う設計**に挑戦しました。
- ギミックの追加・管理をしやすくするため、スクリプトの再利用性を意識しました。

## 反省点・改善したい点
- 継承元の基底クラスにバグがあり、すべての派生クラスに影響してしまい、修正に時間がかかりました。
- → 今後は**インターフェースやイベントベースの設計**も検討し、柔軟で安全な構造を意識したいです。


## 公開ページ（Creators Game Parade）
https://gameparade.creators-guild.com/works/2810

