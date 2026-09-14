using AnthonyB_Portfolio.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnthonyB_Portfolio.Api.Data;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = serviceProvider.GetRequiredService<PortfolioDbContext>();

        // Clear existing data
        context.Categories.RemoveRange(context.Categories);
        context.Skills.RemoveRange(context.Skills);
        context.Projects.RemoveRange(context.Projects);
        context.ProjectDetails.RemoveRange(context.ProjectDetails);
        context.Experiences.RemoveRange(context.Experiences);
        context.Responsibilities.RemoveRange(context.Responsibilities);
        context.SaveChanges();

        // =============================================
        // CATEGORIES
        // =============================================
        var backEndCategory = new Category { Name = "Back-End", DisplayOrder = 1 };
        var frontEndCategory = new Category { Name = "Front-End", DisplayOrder = 2 };
        var databasesCategory = new Category { Name = "Bases de données", DisplayOrder = 3 };
        var toolsCategory = new Category { Name = "Outils & Méthodes", DisplayOrder = 4 };
        var languagesCategory = new Category { Name = "Langues", DisplayOrder = 5 };

        context.Categories.AddRange(
            backEndCategory,
            frontEndCategory,
            databasesCategory,
            toolsCategory,
            languagesCategory
        );
        context.SaveChanges();

        // =============================================
        // SKILLS
        // =============================================
        var csharp = new Skill { Name = "C#", Category = backEndCategory };
        var dotnetFramework = new Skill { Name = ".NET Framework", Category = backEndCategory };
        var entityFramework = new Skill { Name = "Entity Framework", Category = backEndCategory };
        var dotnetCore = new Skill { Name = ".NET Core", Category = backEndCategory };
        var entityFrameworkCore = new Skill { Name = "Entity Framework Core", Category = backEndCategory };
        var php = new Skill { Name = "PHP", Category = backEndCategory };
        var nodejs = new Skill { Name = "Node.js", Category = backEndCategory };
        var express = new Skill { Name = "Express", Category = backEndCategory };
        var symfony = new Skill { Name = "Symfony", Category = backEndCategory };

        var blazor = new Skill { Name = "Blazor", Category = frontEndCategory };
        var javascript = new Skill { Name = "JS", Category = frontEndCategory };
        var react = new Skill { Name = "React", Category = frontEndCategory };
        var angular = new Skill { Name = "Angular", Category = frontEndCategory };
        var html = new Skill { Name = "HTML/CSS", Category = frontEndCategory };
        var sass = new Skill { Name = "Sass/SCSS", Category = frontEndCategory };
        var bootstrap = new Skill { Name = "Bootstrap", Category = frontEndCategory };
        var wpf = new Skill { Name = "WPF", Category = frontEndCategory };

        var sqlLite = new Skill { Name = "SQLite", Category = databasesCategory };
        var sqlServer = new Skill { Name = "SQL Server", Category = databasesCategory };
        var oracle = new Skill { Name = "Oracle", Category = databasesCategory };
        var mariadb = new Skill { Name = "MariaDB", Category = databasesCategory };
        var mongodb = new Skill { Name = "MongoDB", Category = databasesCategory };

        var git = new Skill { Name = "Git", Category = toolsCategory };
        var azure = new Skill { Name = "Azure", Category = toolsCategory };
        var uml = new Skill { Name = "UML", Category = toolsCategory };
        var merise = new Skill { Name = "Merise", Category = toolsCategory };
        var agile = new Skill { Name = "Agile", Category = toolsCategory };
        var cycleEnV = new Skill { Name = "Cycle en V", Category = toolsCategory };

        var french = new Skill { Name = "Français", Category = languagesCategory };
        var english = new Skill { Name = "Anglais", Category = languagesCategory };

        context.Skills.AddRange(
            csharp, dotnetFramework, entityFramework, dotnetCore, entityFrameworkCore, php, nodejs, express, symfony,
            blazor, javascript, react, angular, html, sass, bootstrap, wpf,
            sqlLite, sqlServer, oracle, mariadb, mongodb,
            git, azure, uml, merise, agile, cycleEnV,
            french, english
        );
        context.SaveChanges();

        // =============================================
        // PROJECTS
        // =============================================
        var portfolioWebsite = new Project
        {
            Title = "Portfolio en ligne",
            Description = "Développement d'un portfolio web moderne pour présenter mon parcours professionnel et mes projets notables.",
            IsVisible = true,
            Skills = new List<ProjectSkill>
            {
                new ProjectSkill { Skill = csharp, DisplayOrder = 1, IsHighlighted = true },
                new ProjectSkill { Skill = dotnetCore, DisplayOrder = 2, IsHighlighted = true },
                new ProjectSkill { Skill = blazor, DisplayOrder = 3, IsHighlighted = true },
                new ProjectSkill { Skill = entityFrameworkCore, DisplayOrder = 4 },
                new ProjectSkill { Skill = sqlLite, DisplayOrder = 5 },
                new ProjectSkill { Skill = git, DisplayOrder = 6 }
            },
            Details = new List<ProjectDetail>
            {
                new ProjectDetail { Description = "Développement full-stack avec architecture séparée (API + Frontend)", DisplayOrder = 1 },
                new ProjectDetail { Description = "Base de données SQLite avec Entity Framework Core", DisplayOrder = 2 },
                new ProjectDetail { Description = "Design responsive et interface utilisateur intuitive", DisplayOrder = 3 },
                new ProjectDetail { Description = "Utilisation des outils GitHub pour la sauvegarde", DisplayOrder = 4 },
                new ProjectDetail { Description = "Mise en ligne via Microsoft Azure", DisplayOrder = 5 }
            }
        };

        var phpFramework = new Project
        {
            Title = "Framework PHP Propriétaire",
            Description = "Conception d'un framework PHP structuré pour optimiser la maintenance et le déploiement sur différents projets.",
            IsVisible = true,
            Skills = new List<ProjectSkill> 
            { 
                new ProjectSkill { Skill = php, DisplayOrder = 1, IsHighlighted = true },
                new ProjectSkill { Skill = mariadb, DisplayOrder = 2, IsHighlighted = true },
                new ProjectSkill { Skill = html, DisplayOrder = 3 },
                new ProjectSkill { Skill = javascript, DisplayOrder = 4 },
            },
            Details = new List<ProjectDetail>
            {
                new ProjectDetail { Description = "Conception d'une architecture MVC", DisplayOrder = 1 },
                new ProjectDetail { Description = "Implémentation d'un système de routing personnalisé", DisplayOrder = 2 },
                new ProjectDetail { Description = "Séparation claire de la logique d'accès aux données (DAL)", DisplayOrder = 3 }
            }
        };

        var locationsMimizan = new Project
        {
            Title = "Locations-Mimizan.fr",
            Description = "Création et maintenance d'un site de location : analyse des besoins, développement et hébergement.",
            Url = "https://locations-mimizan.fr",
            IsVisible = true,
            Skills = new List<ProjectSkill> 
            { 
                new ProjectSkill { Skill = php, DisplayOrder = 1, IsHighlighted = true },
                new ProjectSkill { Skill = english, DisplayOrder = 2, IsHighlighted = true },
                new ProjectSkill { Skill = mariadb, DisplayOrder = 3 },
                new ProjectSkill { Skill = html, DisplayOrder = 4 }, 
                new ProjectSkill { Skill = javascript, DisplayOrder = 5 },
            },
            Details = new List<ProjectDetail>
            {
                new ProjectDetail { Description = "Analyse complète des besoins clients et spécifications fonctionnelles", DisplayOrder = 1 },
                new ProjectDetail { Description = "Conception du schéma de base de données avec méthodologie MERISE", DisplayOrder = 2 },
                new ProjectDetail { Description = "Refonte totale avec intégration de reCAPTCHA v3", DisplayOrder = 3 },
                new ProjectDetail { Description = "Traduction complète du site en anglais", DisplayOrder = 4 },
                new ProjectDetail { Description = "Nouvelle refonte en cours de développement (Prévu saison 2027)", DisplayOrder = 5 }
            }
        };

        var lyraWebsite = new Project
        {
            Title = "Lyra-made-a.website",
            Description = "Site web bilingue Pokémon associé à une chaîne YouTube de plus de 80 000 abonnés. Intègre des guides interactifs et des bases de données complexes.",
            Url = "https://lyra-made-a.website",
            IsVisible = true,
            Skills = new List<ProjectSkill> 
            { 
                new ProjectSkill { Skill = php, DisplayOrder = 1, IsHighlighted = true },
                new ProjectSkill { Skill = javascript, DisplayOrder = 2, IsHighlighted = true },
                new ProjectSkill { Skill = english, DisplayOrder = 3, IsHighlighted = true },
                new ProjectSkill { Skill = mariadb, DisplayOrder = 4 },
                new ProjectSkill { Skill = html, DisplayOrder = 5 }, 
            },
            Details = new List<ProjectDetail>
            {
                new ProjectDetail { Description = "Développement d'un site bilingue complet en complément de chaine YouTube", DisplayOrder = 1 },
                new ProjectDetail { Description = "Sauvegarde de plusieurs Pokédex en local, avec un module d'import/export et personnalisation de l'affichage", DisplayOrder = 2 },
                new ProjectDetail { Description = "Intégration de guides interactifs pour la communauté", DisplayOrder = 3 },
                new ProjectDetail { Description = "Gestion de bases de données complexes avec options supplémentaires", DisplayOrder = 4 },
            }
        };

        var moteur2d = new Project
        {
            Title = "Moteur 2D JavaScript",
            Description = "Développement d'un moteur de jeu 2D en JavaScript natif.",
            Details = new List<ProjectDetail>
            {
                new ProjectDetail { Description = "Architecture MVC pour le moteur de jeu", DisplayOrder = 1 },
                new ProjectDetail { Description = "Implémentation d'une boucle de jeu", DisplayOrder = 2 },
                new ProjectDetail { Description = "Gestionnaire d'entrées (input manager) personnalisé", DisplayOrder = 3 },
                new ProjectDetail { Description = "Structuration des données via des DTOs", DisplayOrder = 4 }
            }
        };

        var moduleReact = new Project
        {
            Title = "Module Interactif React",
            Description = "Création d'une interface d'entraînement de jeu en React.",
            Details = new List<ProjectDetail>
            {
                new ProjectDetail { Description = "Interface utilisateur interactive développée en React", DisplayOrder = 1 },
                new ProjectDetail { Description = "Animation 2D chronométrée", DisplayOrder = 2 },
                new ProjectDetail { Description = "Stylisation avec Sass", DisplayOrder = 3 },
                new ProjectDetail { Description = "Gestion audio via la bibliothèque Howler", DisplayOrder = 4 }
            }
        };

        context.Projects.AddRange(portfolioWebsite, phpFramework, locationsMimizan, lyraWebsite, moteur2d, moduleReact);
        context.SaveChanges();

        // =============================================
        // EXPERIENCES
        // =============================================

        // Emploi: Créateur de contenu & Développeur Web Indépendant (Auto-entrepreneur)
        var autoEntrepreneur = new Experience
        {
            Type = ExperienceType.Job,
            Title = "Créateur de contenu YouTube",
            Organization = "Auto-entrepreneur",
            Location = "Télétravail",
            StartTime = new DateTime(2021, 3, 1),
            EndDate = new DateTime(2026, 5, 31),
            Summary = "Gestion complète d'une auto-entreprise de création de contenu",
            IsVisible = true,
            Responsibilities = new List<Responsibility>
            {
                new Responsibility { Description = "Gestion complète d'une auto-entreprise : plannings, négociation avec sponsors", DisplayOrder = 1 },
                new Responsibility { Description = "Animation d'une chaîne YouTube anglophone (> 80 000 abonnés) à temps plein", DisplayOrder = 2 },
                new Responsibility { Description = "Vulgarisation de systèmes complexes via scripts et supports visuels pour un but ludique", DisplayOrder = 3 },
                new Responsibility { Description = "Développement et maintenance du site web bilingue lyra-made-a.website", DisplayOrder = 4 }
            },
            Skills = new List<ExperienceSkill> 
            { 
                new ExperienceSkill { Skill = english, DisplayOrder = 1 },
                new ExperienceSkill { Skill = php, DisplayOrder = 2 }, 
                new ExperienceSkill { Skill = javascript, DisplayOrder = 3 }, 
                new ExperienceSkill { Skill = html, DisplayOrder = 4 }, 
                new ExperienceSkill { Skill = mariadb, DisplayOrder = 5 } 
            }
        };

        // Emploi: Capgemini
        var capgemini = new Experience
        {
            Type = ExperienceType.Job,
            Title = "Concepteur C#",
            Organization = "Capgemini",
            Location = "Bagnols-sur-Cèze, France",
            StartTime = new DateTime(2020, 6, 1),
            EndDate = new DateTime(2021, 3, 31),
            Summary = "Refonte, maintenance et évolution d'applications métiers selon les spécifications clients",
            IsVisible = true,
            Responsibilities = new List<Responsibility>
            {
                new Responsibility { Description = "Refonte, maintenance et évolution d'applications métiers en C#", DisplayOrder = 1 },
                new Responsibility { Description = "Développement en .NET Core, .NET Framework et WPF avec Bootstrap", DisplayOrder = 2 },
                new Responsibility { Description = "Réalisation de scripts de migration de bases de données d'Oracle vers SQL Server", DisplayOrder = 3 },
                new Responsibility { Description = "Rédaction et exécution de tests unitaires, développement de patchs correctifs", DisplayOrder = 4 },
                new Responsibility { Description = "Rédaction de documents de suivi applicatif", DisplayOrder = 5 },
                new Responsibility { Description = "Assistance technique directe aux utilisateurs en visio", DisplayOrder = 6 }
            },
            Skills = new List<ExperienceSkill> 
            { 
                new ExperienceSkill { Skill = csharp }, 
                new ExperienceSkill { Skill = dotnetCore }, 
                new ExperienceSkill { Skill = dotnetFramework }, 
                new ExperienceSkill { Skill = wpf }, 
                new ExperienceSkill { Skill = bootstrap }, 
                new ExperienceSkill { Skill = sqlServer }, 
                new ExperienceSkill { Skill = oracle } 
            }
        };

        // Emploi: 5CA
        var fiveCA = new Experience
        {
            Type = ExperienceType.Job,
            Title = "Agent de Support Client",
            Organization = "5CA",
            Location = "Télétravail",
            StartTime = new DateTime(2018, 7, 1),
            EndDate = new DateTime(2018, 11, 30),
            Summary = "Support technique francophone pour les joueurs du jeu vidéo Fortnite. Proposition de promotion au poste d'Agent Senior.",
            IsVisible = true,
            Responsibilities = new List<Responsibility>
            {
                new Responsibility { Description = "Support technique francophone pour les joueurs de Fortnite", DisplayOrder = 1 },
                new Responsibility { Description = "Résolution de problèmes techniques et respect des procédures internes", DisplayOrder = 2 },
                new Responsibility { Description = "Rédaction de documentation interne avec supports visuels", DisplayOrder = 3 },
                new Responsibility { Description = "Communication interne et lecture de documentation technique en anglais", DisplayOrder = 4 }
            },
            Skills = new List<ExperienceSkill> 
            { 
                new ExperienceSkill { Skill = english } 
            }
        };

        // Emploi: Walibi Sud-Ouest
        var walibi = new Experience
        {
            Type = ExperienceType.Job,
            Title = "Opérateur d'attractions",
            Organization = "Walibi Sud-Ouest",
            Location = "Roquefort, France",
            StartTime = new DateTime(2014, 3, 1),
            EndDate = new DateTime(2014, 10, 31),
            Summary = "Gestion de la sécurité et de l'accueil du public sur les attractions.",
            Responsibilities = new List<Responsibility>
            {
                new Responsibility { Description = "Gestion de la sécurité et de l'accueil du public sur les attractions", DisplayOrder = 1 },
                new Responsibility { Description = "Travail de cohésion d'équipe avec communication constante", DisplayOrder = 2 },
                new Responsibility { Description = "Développement du relationnel client et adaptation à une forte affluence", DisplayOrder = 3 }
            }
        };

        // Emploi: Mericq
        var mericq = new Experience
        {
            Type = ExperienceType.Job,
            Title = "Développeur PHP",
            Organization = "Mericq",
            Location = "Estillac, France",
            StartTime = new DateTime(2012, 10, 1),
            EndDate = new DateTime(2012, 11, 30),
            Summary = "Développement et amélioration des applications internes de l'entreprise (HTML, CSS, PHP, Symfony).",
            IsVisible = true,
            Responsibilities = new List<Responsibility>
            {
                new Responsibility { Description = "Développement et amélioration des applications internes de l'entreprise", DisplayOrder = 1 }
            },
            Skills = new List<ExperienceSkill> 
            { 
                new ExperienceSkill { Skill = php }, 
                new ExperienceSkill { Skill = symfony }, 
                new ExperienceSkill { Skill = html } 
            }
        };

        // Stage: Chrono Informatique
        var chronoInformatique = new Experience
        {
            Type = ExperienceType.Education,
            Title = "Stagiaire Développeur Web",
            Organization = "Chrono Informatique",
            Location = "Agen, France",
            StartTime = new DateTime(2011, 1, 1),
            EndDate = new DateTime(2011, 3, 31),
            Summary = "Développement d'un site e-commerce complet avec partie utilisateur et back-office administrateur dans le cadre du stage de 2ème année de BTS.",
            IsVisible = true,
            Responsibilities = new List<Responsibility>
            {
                new Responsibility { Description = "Développement de la partie utilisateur : recherche de produits, panier, paiement PayPal, création de compte avec historique", DisplayOrder = 1 },
                new Responsibility { Description = "Développement du back-office : gestion des produits, actualités et sauvegarde de la base de données", DisplayOrder = 2 }
            },
            Skills = new List<ExperienceSkill> 
            { 
                new ExperienceSkill { Skill = php }, 
                new ExperienceSkill { Skill = html }, 
                new ExperienceSkill { Skill = javascript } 
            }
        };

        // Stage: Communauté d'Agglomération d'Agen
        var agenAgglo = new Experience
        {
            Type = ExperienceType.Education,
            Title = "Stagiaire Technicien Informatique",
            Organization = "Communauté d'Agglomération d'Agen",
            Location = "Agen, France",
            StartTime = new DateTime(2010, 4, 1),
            EndDate = new DateTime(2010, 6, 30),
            Summary = "Dépannage des matériels informatiques et serveurs, formation des utilisateurs et mise en place de nouveaux postes dans le cadre du stage de 1ère année de BTS.",
            Responsibilities = new List<Responsibility>
            {
                new Responsibility { Description = "Dépannage des divers matériels, postes informatiques et serveurs sur les différents sites", DisplayOrder = 1 },
                new Responsibility { Description = "Formation des utilisateurs sur les différents outils et en bureautique", DisplayOrder = 2 },
                new Responsibility { Description = "Réalisation de fiches guides pour les utilisateurs", DisplayOrder = 3 },
                new Responsibility { Description = "Mise en place de nouveaux postes informatiques", DisplayOrder = 4 },
                new Responsibility { Description = "Reconditionnement des postes usagés en fonction des besoins", DisplayOrder = 5 }
            }
        };

        // Première année IFSI
        var ifsiPremiereAnnee = new Experience
        {
            Type = ExperienceType.Education,
            Title = "Première année IFSI",
            Organization = "Institut de Formation en Soins Infirmiers",
            Location = "Villeneuve-sur-Lot, France",
            StartTime = new DateTime(2017, 9, 1),
            EndDate = new DateTime(2018, 7, 31),
            Summary = "Première année complète en Institut de Formation en Soins Infirmiers. Développement du relationnel avec les patients basé sur l'empathie, le respect et le non-jugement. Travail d'équipe et d'assistance au sein d'environnements à forte pression.",
            Responsibilities = new List<Responsibility>
            {
                new Responsibility { Description = "Formation théorique et pratique en soins infirmiers", DisplayOrder = 1 },
                new Responsibility { Description = "Stage de 4 semaines en EHPAD", DisplayOrder = 2 },
                new Responsibility { Description = "Stage de 8 semaines en hôpital (pôle gastro-entérologie)", DisplayOrder = 3 },
                new Responsibility { Description = "Développement du relationnel avec les patients (empathie, respect, non-jugement)", DisplayOrder = 4 },
                new Responsibility { Description = "Travail d'équipe en milieu médical à forte pression", DisplayOrder = 5 },
                new Responsibility { Description = "Acquisition des bases des soins et de l'accompagnement des patients", DisplayOrder = 6 }
            }
        };

        // Formation: AJC Formation
        var ajcFormation = new Experience
        {
            Type = ExperienceType.Education,
            Title = "Formation C#",
            Organization = "AJC Formation",
            Location = null,
            StartTime = new DateTime(2019, 8, 1),
            EndDate = new DateTime(2019, 11, 30),
            Summary = "Formation intensive couvrant C#, ASP.NET Core & Framework, MVC, Entity Framework, SQL Server, WPF, Angular, Méthode Agile, Design Patterns.",
            IsVisible = true,
            Responsibilities = new List<Responsibility>
            {
                new Responsibility { Description = "Apprentissage de C# et ASP.NET Core & Framework", DisplayOrder = 1 },
                new Responsibility { Description = "Maîtrise de l'architecture MVC et Entity Framework", DisplayOrder = 2 },
                new Responsibility { Description = "Développement avec SQL Server et WPF", DisplayOrder = 3 },
                new Responsibility { Description = "Apprentissage d'Angular et des méthodologies Agile", DisplayOrder = 4 },
                new Responsibility { Description = "Étude des Design Patterns", DisplayOrder = 5 }
            },
            Skills = new List<ExperienceSkill> 
            { 
                new ExperienceSkill { Skill = csharp }, 
                new ExperienceSkill { Skill = dotnetCore }, 
                new ExperienceSkill { Skill = dotnetFramework }, 
                new ExperienceSkill { Skill = entityFramework }, 
                new ExperienceSkill { Skill = sqlServer }, 
                new ExperienceSkill { Skill = wpf }, 
                new ExperienceSkill { Skill = angular }, 
                new ExperienceSkill { Skill = agile }, 
                new ExperienceSkill { Skill = cycleEnV }
            }
        };

        // Formation: freeCodeCamp
        var freeCodeCamp = new Experience
        {
            Type = ExperienceType.Education,
            Title = "Certification Full-Stack JavaScript",
            Organization = "freeCodeCamp",
            Location = null,
            StartTime = new DateTime(2019, 6, 1),
            EndDate = new DateTime(2019, 7, 31),
            Summary = "Certification couvrant le Design Web Réactif, Algorithmes JS, React, Node.js, jQuery, D3, Express, MongoDB.",
            IsVisible = true,
            Responsibilities = new List<Responsibility>
            {
                new Responsibility { Description = "Design Web Réactif et développement front-end", DisplayOrder = 1 },
                new Responsibility { Description = "Maîtrise des algorithmes JavaScript", DisplayOrder = 2 },
                new Responsibility { Description = "Développement full-stack avec React, Node.js et Express", DisplayOrder = 3 },
                new Responsibility { Description = "Utilisation de jQuery, D3 et MongoDB", DisplayOrder = 4 }
            },
            Skills = new List<ExperienceSkill> 
            { 
                new ExperienceSkill { Skill = javascript }, 
                new ExperienceSkill { Skill = react }, 
                new ExperienceSkill { Skill = nodejs }, 
                new ExperienceSkill { Skill = express }, 
                new ExperienceSkill { Skill = mongodb }, 
                new ExperienceSkill { Skill = html } 
            }
        };

        // Formation: BTS Informatique de Gestion
        var btsIg = new Experience
        {
            Type = ExperienceType.Education,
            Title = "BTS Informatique de Gestion - Option Développeur d'Applications",
            Organization = "Lycée Gustave Eiffel",
            Location = "Bordeaux",
            StartTime = new DateTime(2009, 9, 1),
            EndDate = new DateTime(2011, 6, 30),
            Summary = "BTS en gestion informatique avec spécialisation en développement logiciel. Cursus couvrant l'algorithmie, la programmation orientée objet et la modélisation de bases de données (UML, SQL).",
            IsVisible = true,
            Responsibilities = new List<Responsibility>
            {
                new Responsibility { Description = "Apprentissage de l'algorithmie avancée", DisplayOrder = 1 },
                new Responsibility { Description = "Maîtrise de la Programmation Orientée Objet", DisplayOrder = 2 },
                new Responsibility { Description = "Modélisation de Bases de Données avec UML et SQL", DisplayOrder = 3 }
            },
            Skills = new List<ExperienceSkill> 
            { 
                new ExperienceSkill { Skill = uml }, 
                new ExperienceSkill { Skill = php }, 
                new ExperienceSkill { Skill = html }, 
                new ExperienceSkill { Skill = javascript } 
            }
        };

        context.Experiences.AddRange(
            autoEntrepreneur, capgemini, fiveCA, walibi, mericq,
            chronoInformatique, agenAgglo, ifsiPremiereAnnee,
            ajcFormation, freeCodeCamp, btsIg
        );
        context.SaveChanges();
    }
}