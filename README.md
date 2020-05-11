# Medical Inspection Kata - Elapse Technologies

Ce kata a pour but de pratiquer différentes techniques de refactoring à partir d'une base de code existante correctement couverte par des tests.

## Instructions

Votre mission est d'ajouter une à une les fonctionnalités listées ci-dessous (tout en conservant les comportements de base) sans jamais briser aucun des tests existants. N'essayez pas de réfléchir d'avance à un design qui pourrait satisfaire toutes les exigences du premier coup. Faites l'effort d'implémenter chaque étape les unes après les autres dans le but d'intégrer continuellement de petits changements et pratiquer les techniques refactoring.

Le code que vous produisez doit avoir un minimum de duplication (aucune si possible) et doit respecter au maximum les principes SOLID. Idéalement, les nouvelles fonctionnalités devraient être testées adéquatement.

En aucun cas vous ne pouvez modifier du code existant en même temps que vous ajoutez une nouvelle fonctionnalité ou une nouvelle règle. Si vous devez modifier du code, annulez vos changements, faites la modification, _commit_ la modification et seulement après vous pourrez implémenter la nouvelle fonctionnalité.

Faites de petits commits. Idéalement après chaque petite modification ou petite règle ajoutée.

Pour valider que vous ne brisez aucun tests, vous pouvez exécuter le script `watch-tests` (dans le dossier du projet) qui exécutera tous les tests après chaque modification au code.

Si vous brisez un test (erreur de compilation ou test échoué), annulez vos derniers changements avec `reset-changes`. Ce script annule tous les changements qui n'ont pas été _commit_ avec git.

## Comportements de base

Il s'agit d'une petite application permettant de faire l'inspection d'appareils médicaux d'une entreprise.

Le comportement actuel est très simple:
- nous pouvons inspecter un défibrillateur existant;
- suite à une inspection, la prochaine date d'inspection d'un défibrillateur est 1 mois plus tard;
- un défibrillateur dont la prochaine date d'inspection est dans le passé est considéré "non inspecté";
- un défibrillateur dont la prochaine date d'inspection est dans moins de 2 semaines est considéré "à inspecter";
- un défibrillateur dont la prochaine date d'inspection est dans plus de 2 semaines est considéré "inspecté".

## Fonctionnalités à ajouter

**Composante d'un défibrillateur**
- ajouter des composantes à un défibrillateur (exemple: batterie de rechange) ayant une date d'expiration;
- un défibrillateur dont une de ses composantes expire dans plus de 2 semaines est considéré "inspecté";
- un défibrillateur dont une de ses composantes expire dans moins de 2 semaines est considéré "à inspecter";
- un défibrillateur dont une de ses composantes est expirée (date d'expiration dans le passé) est considéré "non sécuritaire".

**Sac de premiers secours**
- supporter l'inspection de sac de premiers secours;
- un sac peut contenir un défibrillateur;
- les mêmes règles que ci-dessus concernant la prochaine date d'inspection d'un défibrillateur s'appliquer;
- si le défibrillateur contenu dans le sac est considéré "à inspecter", le sac est considéré "à inspecter";
- si le défibrillateur contenu dans le sac est considéré "non inspecté", le sac est considéré "non inspecté".

**Composante d'un sac de premiers secours**
- ajouter des composantes à un sac (exemple: pansements) ayant une date d'expiration;
- les mêmes règles que d'expiration que les composantes d'un défibrillateur s'appliquent.

**Extincteur**
- supporter l'inspection d'un extincteur;
- suite à une inspection, la prochaine d'inspection d'un extincteur est 2 semaines (14 jours) plus tard;
- un extincteur dont la prochaine date d'inspection est dans le passé est considéré "non inspecté";
- un extincteur dont la prochaine date d'inspection est dans moins de 1 semaine est considéré "à inspecter";
- un extincteur dont la prochaine date d'inspection est dans plus de 1 semaine est considéré "inspecté".

**Ambulance**
- supporter l'inspection d'une ambulance;
- suite à une inspection, la prochaine d'inspection d'une ambulance est 1 semaine (7 jours) plus tard;
- une ambulance dont la prochaine date d'inspection est dans le passé est considéré "non inspecté";
- une ambulance dont la prochaine date d'inspection est dans moins de 3 jours est considéré "à inspecter";
- une ambulance dont la prochaine date d'inspection est dans plus de 3 jours est considéré "inspecté";
- une ambulance peut contenir plusieurs sacs de premiers secours;
- une ambulance peut contenir plusieurs extincteurs;
- une ambulance peut contenir plusieurs défibrillateurs;
- si un des sacs, extincteurs ou défibrillateurs contenu dans l'ambulance est considéré "à inspecter", l'ambulance est considérée "à inspecter";
- si un des sacs, extincteurs ou défibrillateurs contenu dans l'ambulance est considéré "non inspecté", l'ambulance est considérée "non inspectée";
