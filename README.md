# 🐉 Dungeon do Destino – Mini RPG em C#

Bem-vindo à **Dungeon do Destino**, um projeto simples de **RPG de texto** desenvolvido em **C#** com o objetivo principal de praticar os pilares da Programação Orientada a Objetos (POO), como encapsulamento, herança e organização modular em classes.

---

## 🎯 Objetivo do Projeto

Este jogo é um **mini dungeon crawler** projetado para ser concluído em **menos de cinco minutos**. O foco é a estrutura de lógica, combate e decisões do jogador, funcionando como um exercício prático de programação em C# para uso em portfólio e aprendizagem.

---

## ⚔️ Como funciona

- O jogador inicia com uma escolha de equipamento (foco em ataque ou defesa).
- Entra em uma dungeon e enfrenta um inimigo aleatório (zumbi ou esqueleto).
- Após o combate, encontra um baú misterioso que pode conter recompensas ou um mímico (inimigo disfarçado).
- Por fim, enfrenta um **chefe final**: um poderoso **dragão esqueleto**.
- O jogo conta com sistema de ataque, poções de cura, fuga e aleatoriedade nas escolhas e eventos.

---

## 📁 Estrutura do Projeto

O projeto está dividido em várias classes:

- `Program.cs` – fluxo principal da aventura
- `Player.cs` – representação do jogador
- `Equipamento.cs` – armas e escudos
- `personagem.cs` – classe base para todos os personagens
- `Mob.cs` – inimigos: zumbi, esqueleto, mímico e chefe final

---

## 🚧 Versão atual: v1.0

Esta é a **primeira versão** funcional do projeto. Ela cumpre todos os objetivos definidos para este estágio:

✅ Combate entre jogador e inimigos  
✅ Sistema de poções e cura  
✅ Baú com risco ou recompensa  
✅ Combate final contra um boss  
✅ Uso de herança, classes separadas e lógica de combate baseada em dados

---

## 🛠️ Próximas melhorias (versão futura)

Algumas ideias planejadas para versões futuras:

- Reorganização interna com **padrões de design simples** (ex: SRP, interface básica)
- Modularização ainda maior das responsabilidades
- Mais variedade de inimigos e eventos aleatórios
- Salvamento e carregamento de progresso (save system)
- Implementação de elementos visuais simples via console (ex: ASCII art)

---

## 🧠 Motivação

Este projeto foi criado com foco no **aprendizado prático de programação orientada a objetos** e para ser incluído no portfólio como demonstração de lógica, organização e desenvolvimento em C# puro, sem bibliotecas externas.

---

## 🚀 Como rodar

- Abra o projeto no **Visual Studio**
- Compile e execute (`Ctrl + F5`)
- O jogo será executado inteiramente no console

---

## 📌 Licença

Este projeto é livre para uso educacional ou como base para projetos pessoais.  
Sinta-se à vontade para clonar, melhorar e adaptar.
