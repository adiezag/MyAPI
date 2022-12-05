CREATE DATABASE additivedatabase;
USE additivedatabase;
CREATE TABLE AdditiveType(
Id INT NOT NULL AUTO_INCREMENT,
AdditiveTypeName VARCHAR(1000) NOT NULL,
PRIMARY KEY(Id)
);
CREATE TABLE Additive(
Id INT NOT NULL AUTO_INCREMENT,
AdditiveName VARCHAR(1000),
WaterBased BOOLEAN NOT NULL,
OilBased BOOLEAN NOT NULL,
Info VARCHAR(1000),
AdditiveTypeId INT,
PRIMARY KEY (Id)
);
ALTER TABLE Additive ADD CONSTRAINT FK_TypeId FOREIGN KEY (AdditiveTypeId) REFERENCES AdditiveType(Id);
INSERT INTO AdditiveType(AdditiveTypeName) VALUES ('Alcalinity Control');
INSERT INTO AdditiveType(AdditiveTypeName) VALUES ('Filtration Reducer');
INSERT INTO AdditiveType(AdditiveTypeName) VALUES ('Viscosifier');
INSERT INTO AdditiveType(AdditiveTypeName) VALUES ('Weighting Agent');
INSERT INTO Additive(AdditiveName, WaterBased, OilBased, Info, AdditiveTypeId) VALUES('Barite', TRUE, TRUE, 'Increases the density of any drilling fluid system up to 20 lb/gal while still maintainng good rheological properties.', 4);
INSERT INTO Additive(AdditiveName, WaterBased, OilBased, Info, AdditiveTypeId) VALUES('Caustic Soda', TRUE, FALSE, 'Strong base which is extremely soluble in water. Used to maintain or increase pH and precipitates magnesium and suppresses calcium in high hardness waters such as seawater, reduces corrosion and neutralizes acid gases such as carbon dioxide and hydrogen sulfide.', 1);
INSERT INTO Additive(AdditiveName, WaterBased, OilBased, Info, AdditiveTypeId) VALUES('Hematite', TRUE, TRUE, 'Weighting agent with a specific gravity of 5.0 or above. Drilling fluids formulated with hematite haave lower solids content and contribute to higher rates of penetration compared to barite fluids.', 4);
INSERT INTO Additive(AdditiveName, WaterBased, OilBased, Info, AdditiveTypeId) VALUES('Bentonite', TRUE, FALSE, 'Increases viscosity and reduces fluid loss in water-based drilling fluids. Hydrates more than any other types of clays and is best for generating viscosity, developing gels for suspension, and controlling filtration.', 3);
INSERT INTO Additive(AdditiveName, WaterBased, OilBased, Info, AdditiveTypeId) VALUES('POLYPAC UL', TRUE, FALSE, 'Polyanionic cellulose is a high quality, water soluble polymer designed to control fluid loss, and because it is an ultra low additive, it causes a minimal increase in viscosity in water-based fluids.', 2);
INSERT INTO Additive(AdditiveName, WaterBased, OilBased, Info, AdditiveTypeId) VALUES('POLYPAC R', TRUE, FALSE, 'Polyanionic-cellulose filtration-control additive controls fluid loss in freshwater, seawater. This polymer forms a thin, resilient, low-permeability filtercake that minimizes the potential for differential sticking and the invasion of the filtrate and fluid solids into permeable formations.', 2);
INSERT INTO Additive(AdditiveName, WaterBased, OilBased, Info, AdditiveTypeId) VALUES('DUO-VIS', TRUE, FALSE, 'Biopolymer viscosifier that provides viscosity and weight material suspension for all water-based systems It deliveres an optimized rheological profile with elevated low-shear-rate viscosity and highly shear-thinning characteristics.', 3);
INSERT INTO Additive(AdditiveName, WaterBased, OilBased, Info, AdditiveTypeId) VALUES('Sodium carbonate', TRUE, FALSE, 'Weak base that is soluble in water and dissociates into sodium and carbonate ions in solution. Increases pH, and reduces soluble calcium in water-based muds.', 1);

