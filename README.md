# Space-War-Windows-Phone

# Introduction

Ce jeu a été conçu en 2013 avec XNA, un moteur de jeu écrit en C#. Le moteur alterne en permanence une phase Update, qui modifie les variables des éléments du jeu et une phase Draw qui dessine les différents éléments. Toutes les classes sont structurées avec ces méthodes.
Le jeu est divisé en 2 écrans : l'écran d'acceuil (avec ScrollingBackground et les deux boutons) et l'écran de jeu. La classe GameScreen gère la logique du jeu.

# Architecture des différents éléments

Tous les éléments du jeu héritent de la classe Mere, qui leur donne les méthodes de bases pour se déplacer, se dessiner et se collisioner.
Il y a ensuite les armes et les personnages qui sont les parents d'autres classes plus spécifiques.

Les classes ContentManager et ScreenManager permettent de gérer respectivement le chargement des différentes ressources et des transitions entre les écrans.
