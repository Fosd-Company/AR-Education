using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class Data
{
    public static List<ARModel> models = new List<ARModel> {
        new ARModel
        {
            ID = 1,
            Name = "Atom",
            Type = "Particles",
            Book = "Complete Physics for Cambridge",
            Description =
            "Un átomo es la unidad más pequeña de la materia que tiene las propiedades " +
            "de un elemento químico. Los átomos son microscópicos, los tamaños típicos son " +
            "alrededor de 100pm. Cada átomo se compone de un núcleo y uno o más electrones " + 
            "unidos al núcleo. El núcleo está compuesto por uno o más protones y típicamente " +
            "por igual número de neutrones."
        },
        new ARModel
        {
            ID = 2,
            Name = "Axe",
            Type = "Prehistoric Tools",
            Book = "World History",
            Description =
            "Las herramientas de piedras como las que se representan en el modelo anterior " + 
            "permitieron que los primeros representantes del género Homo consiguieran adaptarse " + 
            "al medio ambiente en el que habitaban y consiguieran un a explotacióna de recursos " + 
            "más eficientes. Este tipo de herramientas se utilizó para cortar la carne, plantas, maleza, etc."
        },
        new ARModel
        {
            ID = 3,
            Name = "Bow",
            Type = "Prehistoric Tools",
            Book = "World History",
            Description =
            "Es una arma flexible que dispara proyectiles aerodinámicos denominados flechas. " + 
            "En la edad de piedra, la gente usaba huesos afilados, piedras talladas, escamas y " + 
            "trozos de roca como armas y herramientas. Los elementos básicos de un arco son un " + 
            "par de miembros flexibles curvos, unidos por una mazarota y con ambos extremos " + 
            "conectados con una cuerda."
        },
        new ARModel
        {
            ID = 4,
            Name = "Capside",
            Type = "Virus Parts",
            Book = "Oxford Natural Sciences",
            Description =
            "Es una estructura protéica formada por una serie de monómeros llamados capsómeros. " + 
            "En el interior de esta cápside se encuentra siempre el material genético del virus. " + 
            "Puede estar rodeada por una envoltura y cada capsómero puede estar constituido por " + 
            "una o varias proteínas distintas."
        },
        new ARModel
        {
            ID = 5,
            Name = "Caravel",
            Type = "History",
            Book = "Prentice Hall American History",
            Description =
            "Una carabela es una embarcación a vela ligera usada en viajes oceánicos en los siglos " + 
            "XV y XVI por Portugal y España. En los años posteriores al descubrimiento y la conquista " + 
            "y colonización de América, las carabelas fueron cayendo en desuso en la medida que " + 
            "aparecieron nuevos tipos de embarcaciones, especialmente los galeones"
        },
        new ARModel
        {
            ID = 6,
            Name = "Digestion",
            Type = "Body Parts",
            Book = "Anatomy & Physiology",
            Description =
            "El aparato digestivo está formado por el tracto gastrointestinal y el hígado, el páncreas " + 
            "y la vesícula biliar. El tracto gastrointestinal es una serie de órganos huecos unidos en " + 
            "un tubo largo y retorcido que va desde la boca hasta el ano."
        },
        new ARModel
        {
            ID = 7,
            Name = "DNA",
            Type = "Molecules",
            Book = "Anatomy & Physiology",
            Description =
            "Es el material que contiene la información hereditaria en los humanos y casi todos los demás " + 
            "organismos. Casi todas las células del cuerpo de una persona tienen el mismo ADN. La mayor parte " + 
            "del ADN se encuentra en el núcleo celular (o ADN nuclear), pero también se puede encontrar una " + 
            "pequeña cantidad de ADN en las mitocondrias."
        },
        new ARModel
        {
            ID = 8,
            Name = "Earth",
            Type = "Geography",
            Book = "Oxford Essential Biology",
            Description =
            "La Tierra es nuestro planeta y el único habitado. Está situado en la ecosfera, un espacio que " + 
            "rodea al Sol y que tiene las condiciones adecuadas para que exista vida. Su tamaño hace que pueda " + 
            "retener una capa de gases, la atmósfera, que dispersa la luz solar y absorbe calor. De día evita " + 
            "que nuestro planeta se caliente demasiado y, de noche, que se enfríe."
        },
        new ARModel
        {
            ID = 9,
            Name = "Fungus",
            Type = "Environment",
            Book = "Oxford Essential Biology",
            Description =
            "Los hongos son un grupo de microorganismos eucariotas, que posee unas características " + 
            "biológicas que los diferencia tanto del reino vegetal como del animal, formando un reino propio."
        },
        new ARModel
        {
            ID = 10,
            Name = "Tree",
            Type = "Environment",
            Book = "Oxford Essential Biology",
            Description =
            "Un bosque es un ecosistema donde la vegetación predominante la constituyen los árboles y " + 
            "arbustos. Estas comunidades de plantas cubren grandes áreas de la Tierra y constituyen " + 
            "hábitats para los animales, moduladores de flujos hidrológicos y conservadores del suelo, " + 
            "siendo uno de los aspectos más relevantes de la biosfera del globo terráqueo."
        },
        new ARModel
        {
            ID = 11,
            Name = "Omicron",
            Type = "Virus",
            Book = "Medical Microbiology",
            Description =
            "Es una subfamilia de virus ARN monocatenario positivos perteneciente a la familia " + 
            "Coronaviridae. Los coronavirus pueden infectar aves y mamíferos produciendo una serie " + 
            "de enfermedades respiratorias y digestivas. Hasta la fecha se han registrado cuarenta " + 
            "y cinco especies de coronavirus."
        }
    };
}

public class ARModel
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Book { get; set; }
    public string Description { get; set; }
}