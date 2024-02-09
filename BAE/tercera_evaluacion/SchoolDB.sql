-- Create SchoolDB database
CREATE DATABASE SchoolDB;
GO

-- Use SchoolDB
USE SchoolDB;
GO

IF OBJECT_ID('Branch', 'U') IS NOT NULL DROP TABLE Branch; 
IF OBJECT_ID('Degree', 'U') IS NOT NULL DROP TABLE Degree; 
IF OBJECT_ID('Teachers', 'U') IS NOT NULL DROP TABLE Teachers; 
IF OBJECT_ID('Courses', 'U') IS NOT NULL DROP TABLE Courses; 
IF OBJECT_ID('TeacherCourses', 'U') IS NOT NULL DROP TABLE TeacherCourses; 
IF OBJECT_ID('Subjects', 'U') IS NOT NULL DROP TABLE Subjects; 
IF OBJECT_ID('CourseSubjects', 'U') IS NOT NULL DROP TABLE CourseSubjects; 
IF OBJECT_ID('Students', 'U') IS NOT NULL DROP TABLE Students; 
IF OBJECT_ID('StudentSubjects', 'U') IS NOT NULL DROP TABLE StudentSubjects; 
IF OBJECT_ID('Marks', 'U') IS NOT NULL DROP TABLE Marks; 
GO

-- Create Branch table
CREATE TABLE Branch (
  branch_id INT PRIMARY KEY,
  branch_name VARCHAR(100) NOT NULL UNIQUE
);
GO

-- Create Degree table
CREATE TABLE Degree (
  id_degree INT PRIMARY KEY,
  degree_name VARCHAR(50) NOT NULL CHECK (degree_name IN ('Grado medio', 'Grado superior'))
);
GO

-- Create Teachers table
CREATE TABLE Teachers (
  teacher_id INT PRIMARY KEY,
  first_name VARCHAR(50) NOT NULL,
  last_name VARCHAR(50) NOT NULL,
  date_of_birth DATE NOT NULL,
  gender VARCHAR(10) NOT NULL CHECK (gender IN ('Male', 'Female')),
  address VARCHAR(100) NOT NULL,
  contact_number VARCHAR(9) NOT NULL UNIQUE CHECK (LEN(contact_number) = 9),
  email VARCHAR(100) NOT NULL UNIQUE CHECK (email LIKE '%_@__%.%')
);
GO

-- Create Courses table
CREATE TABLE Courses (
  course_id INT PRIMARY KEY,
  course_name VARCHAR(100) NOT NULL UNIQUE,
  branch_id INT NOT NULL,
  id_degree INT NOT NULL,
  FOREIGN KEY (branch_id) REFERENCES Branch(branch_id),
  FOREIGN KEY (id_degree) REFERENCES Degree(id_degree)
);
GO

-- Create TeacherCourses table
CREATE TABLE TeacherCourses (
  teacher_id INT NOT NULL,
  course_id INT NOT NULL,
  PRIMARY KEY (teacher_id, course_id),
  FOREIGN KEY (teacher_id) REFERENCES Teachers(teacher_id),
  FOREIGN KEY (course_id) REFERENCES Courses(course_id)
);
GO

-- Create Subjects table
CREATE TABLE Subjects (
  subject_id INT PRIMARY KEY,
  subject_name VARCHAR(100) NOT NULL UNIQUE
);
GO

-- Create CourseSubjects table 
CREATE TABLE CourseSubjects (
  course_id INT NOT NULL,
  subject_id INT NOT NULL,
  PRIMARY KEY (course_id, subject_id),
  FOREIGN KEY (course_id) REFERENCES Courses(course_id),
  FOREIGN KEY (subject_id) REFERENCES Subjects(subject_id)
);
GO

-- Create Students table
CREATE TABLE Students (
  student_id INT PRIMARY KEY,
  first_name VARCHAR(50) NOT NULL,
  last_name VARCHAR(50) NOT NULL,
  date_of_birth DATE NOT NULL CHECK (date_of_birth <= GETDATE()),
  gender VARCHAR(10) NOT NULL CHECK (gender IN ('Male', 'Female')),
  address VARCHAR(100) NOT NULL,
  contact_number VARCHAR(9) NOT NULL UNIQUE CHECK (LEN(contact_number) = 9),
  email VARCHAR(100) NOT NULL UNIQUE CHECK (email LIKE '%_@__%.%'),
  course_id INT NOT NULL,
  FOREIGN KEY (course_id) REFERENCES Courses(course_id)
);
GO

-- Create StudentSubjects table
CREATE TABLE StudentSubjects (
  student_id INT NOT NULL,
  subject_id INT NOT NULL,
  PRIMARY KEY (student_id, subject_id),
  FOREIGN KEY (student_id) REFERENCES Students(student_id),
  FOREIGN KEY (subject_id) REFERENCES Subjects(subject_id)
);
GO

-- Create Marks table
CREATE TABLE Marks (
  mark_id INT PRIMARY KEY,
  student_id INT NOT NULL,
  subject_id INT NOT NULL,
  quarter INT NOT NULL CHECK (quarter IN (1, 2, 3)),
  marks INT NOT NULL CHECK (marks >= 0 AND marks <= 10),
  average_mark AS CAST(ROUND(marks, 0) AS INT),
  FOREIGN KEY (student_id) REFERENCES Students(student_id),
  FOREIGN KEY (subject_id) REFERENCES Subjects(subject_id)
);
GO

-- Insert values to Degree
INSERT INTO Degree (id_degree, degree_name) VALUES (1, 'Grado medio'), (2, 'Grado superior');
GO

-- Insert values to Branch
insert into Branch (branch_id, branch_name) values (1, 'Administración y gestión');
insert into Branch (branch_id, branch_name) values (2, 'Comercio y marketing');
insert into Branch (branch_id, branch_name) values (3, 'Electricidad y electrónica');
insert into Branch (branch_id, branch_name) values (4, 'Imagen y sonido');
insert into Branch (branch_id, branch_name) values (5, 'Informática y comunicaciones');
GO

-- Insert values to Teachers
SET DATEFORMAT dmy;
GO
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (1, 'Theresita', 'Karel', '22/03/1965', 'Female', '87807 Michigan Parkway', 668901154, 'tkarel0@blogspot.com');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (2, 'Antons', 'Kenzie', '22/08/1982', 'Male', '56128 Clyde Gallagher Street', 817325470, 'akenzie1@blogs.com');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (3, 'Vonny', 'Klaassens', '19/09/1975', 'Female', '745 Canary Parkway', 454713686, 'vklaassens2@squarespace.com');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (4, 'Dulcia', 'Tiuit', '12/03/1981', 'Female', '4599 Marquette Junction', 431732795, 'dtiuit3@wordpress.org');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (5, 'Jewelle', 'Braim', '10/05/1960', 'Female', '26 Commercial Way', 475347974, 'jbraim4@usa.gov');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (6, 'Koo', 'Shorter', '30/05/1972', 'Female', '401 Ridgeway Crossing', 164093653, 'kshorter5@about.me');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (7, 'Cedric', 'Coleyshaw', '14/05/1977', 'Male', '7323 Claremont Road', 806432258, 'ccoleyshaw6@squarespace.com');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (8, 'Craggie', 'Cocke', '08/09/1965', 'Male', '8 Scofield Trail', 668352099, 'ccocke7@soundcloud.com');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (9, 'Dinnie', 'Pitts', '02/09/1965', 'Female', '086 Novick Way', 372470915, 'dpitts8@livejournal.com');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (10, 'Arleen', 'Fennelly', '11/08/1963', 'Female', '59905 Mcguire Place', 611285230, 'afennelly9@yale.edu');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (11, 'Nickolai', 'Urquhart', '18/11/1989', 'Male', '00839 Pennsylvania Circle', 396054938, 'nurquharta@usda.gov');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (12, 'Brandy', 'English', '28/02/1987', 'Female', '15 Talmadge Road', 738152527, 'benglishb@eepurl.com');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (13, 'Halimeda', 'Culligan', '15/04/1975', 'Female', '047 Lunder Place', 761456716, 'hculliganc@rediff.com');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (14, 'Sayres', 'Bumpas', '30/04/1976', 'Male', '6 Anderson Junction', 731746347, 'sbumpasd@nhs.uk');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (15, 'Orazio', 'McMillan', '06/01/1996', 'Male', '636 Shasta Drive', 121419952, 'omcmillane@apache.org');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (16, 'Corty', 'Coch', '01/05/1986', 'Male', '6 Randy Place', 579780148, 'ccochf@toplist.cz');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (17, 'Tulley', 'Jennaway', '22/11/1984', 'Male', '844 Mayer Crossing', 183179560, 'tjennawayg@360.cn');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (18, 'Cello', 'Assaf', '05/01/1965', 'Male', '05 Steensland Trail', 926761727, 'cassafh@oaic.gov.au');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (19, 'Teador', 'Itzakovitz', '27/10/1969', 'Male', '61589 Golf View Park', 330575026, 'titzakovitzi@slashdot.org');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (20, 'Emlynn', 'Hagerty', '22/06/1970', 'Female', '61172 Lakewood Park', 272847685, 'ehagertyj@umn.edu');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (21, 'Sammie', 'Cubin', '14/03/1985', 'Male', '2864 Prentice Alley', 638743957, 'scubink@soundcloud.com');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (22, 'Eartha', 'Woodus', '10/10/1974', 'Female', '6 Upham Circle', 558383418, 'ewoodusl@apple.com');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (23, 'Jimmie', 'Rustan', '13/09/1995', 'Male', '23 Elgar Terrace', 380010721, 'jrustanm@hhs.gov');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (24, 'Jerad', 'Giddings', '17/05/1978', 'Male', '6022 Nobel Terrace', 202474041, 'jgiddingsn@admin.ch');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (25, 'Marika', 'Tapner', '15/08/1993', 'Female', '9013 Gina Junction', 810771616, 'mtapnero@usda.gov');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (26, 'Gratiana', 'Cull', '09/04/1995', 'Female', '600 1st Place', 818019398, 'gcullp@usa.gov');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (27, 'Paulina', 'Dibsdale', '18/09/1996', 'Female', '5783 Burning Wood Alley', 430283518, 'pdibsdaleq@dell.com');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (28, 'Elwood', 'Bewlay', '28/06/1966', 'Male', '65 Welch Center', 398361443, 'ebewlayr@mozilla.com');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (29, 'Donn', 'Bridge', '26/02/1960', 'Male', '00 Morrow Pass', 244014347, 'dbridges@is.gd');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (30, 'Alaine', 'Wernher', '01/12/1972', 'Female', '4648 Thackeray Alley', 268467027, 'awernhert@ftc.gov');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (31, 'Yankee', 'Shitliffe', '19/05/1997', 'Male', '6877 Starling Parkway', 616529961, 'yshitliffeu@blinklist.com');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (32, 'Bink', 'Eede', '11/09/1969', 'Male', '2 Gale Center', 478781491, 'beedev@fda.gov');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (33, 'Moishe', 'Refford', '01/04/1965', 'Male', '1 Becker Avenue', 113075623, 'mreffordw@vkontakte.ru');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (34, 'Justinian', 'Ainslie', '06/11/1968', 'Male', '0950 Paget Drive', 340634949, 'jainsliex@answers.com');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (35, 'Erin', 'Gillmor', '21/12/1975', 'Male', '1753 Summer Ridge Alley', 586271871, 'egillmory@biblegateway.com');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (36, 'Zaccaria', 'Andrusov', '09/09/1976', 'Male', '01594 Fremont Parkway', 747906077, 'zandrusovz@dailymail.co.uk');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (37, 'Lorettalorna', 'Simes', '05/12/1966', 'Female', '64 Pond Lane', 271049204, 'lsimes10@cam.ac.uk');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (38, 'Thebault', 'Mallinson', '05/11/1991', 'Male', '416 Waubesa Junction', 952179893, 'tmallinson11@salon.com');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (39, 'Tessie', 'Antrag', '27/01/1998', 'Female', '750 Magdeline Park', 801556542, 'tantrag12@diigo.com');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (40, 'Willamina', 'Belliveau', '26/12/1996', 'Female', '59706 Manitowish Way', 306302452, 'wbelliveau13@themeforest.net');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (41, 'Rachael', 'Bouts', '15/08/1994', 'Female', '7 Kinsman Plaza', 316146701, 'rbouts14@go.com');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (42, 'Lynett', 'Tineman', '10/07/1979', 'Female', '1788 Dakota Lane', 733307347, 'ltineman15@adobe.com');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (43, 'Gregorius', 'Ibbetson', '22/08/1987', 'Male', '730 Eagan Trail', 146502969, 'gibbetson16@pinterest.com');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (44, 'Christoph', 'Cathcart', '08/07/1965', 'Male', '9095 Meadow Valley Center', 710794620, 'ccathcart17@globo.com');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (45, 'Welbie', 'Ellerby', '06/10/1973', 'Male', '11 Debs Way', 715187829, 'wellerby18@sourceforge.net');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (46, 'Jarad', 'Bamblett', '16/08/1966', 'Male', '8991 Sage Circle', 724617007, 'jbamblett19@google.com');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (47, 'Linus', 'Lambert-Ciorwyn', '18/11/1973', 'Male', '5669 Barby Street', 810874553, 'llambertciorwyn1a@imageshack.us');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (48, 'Gayleen', 'Knowlden', '18/08/1966', 'Female', '3003 Esker Avenue', 553188447, 'gknowlden1b@w3.org');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (49, 'Roma', 'Ivantyev', '21/01/1978', 'Male', '0 Pond Parkway', 749595187, 'rivantyev1c@elegantthemes.com');
insert into Teachers (teacher_id, first_name, last_name, date_of_birth, gender, address, contact_number, email) values (50, 'Hillel', 'Dreinan', '21/12/1993', 'Male', '81 Rusk Plaza', 914889210, 'hdreinan1d@canalblog.com');
GO

-- Insert values to Courses
insert into Courses (course_id, course_name, branch_id, id_degree) values (1, 'Gestión Administrativa', 1, 1);
insert into Courses (course_id, course_name, branch_id, id_degree) values (2, 'Gestión Administrativa a Distancia', 1, 1);
insert into Courses (course_id, course_name, branch_id, id_degree) values (3, 'Administración y Finanzas', 1, 2);
insert into Courses (course_id, course_name, branch_id, id_degree) values (4, 'Administración y Finanzas a Distancia', 1, 2);
insert into Courses (course_id, course_name, branch_id, id_degree) values (5, 'Asistencia a la Dirección', 1, 2);
insert into Courses (course_id, course_name, branch_id, id_degree) values (6, 'Asistencia a la Dirección a Distancia', 1, 2);

insert into Courses (course_id, course_name, branch_id, id_degree) values (7, 'Actividades Comerciales', 2, 1);
insert into Courses (course_id, course_name, branch_id, id_degree) values (8, 'Comercio Internacional', 2, 2);
insert into Courses (course_id, course_name, branch_id, id_degree) values (9, 'Comercio Internacional a Distancia', 2, 2);
insert into Courses (course_id, course_name, branch_id, id_degree) values (10, 'Transporte y Logística', 2, 2);
insert into Courses (course_id, course_name, branch_id, id_degree) values (11, 'Gestión de Ventas y Espacios Comerciales', 2, 2);
insert into Courses (course_id, course_name, branch_id, id_degree) values (12, 'Marketing y Publicidad', 2, 2);

insert into Courses (course_id, course_name, branch_id, id_degree) values (13, 'Instalaciones de Telecomunicaciones', 3, 1);
insert into Courses (course_id, course_name, branch_id, id_degree) values (14, 'Instalaciones Eléctricas y Automáticas', 3, 1);
insert into Courses (course_id, course_name, branch_id, id_degree) values (15, 'Mantenimiento Electrónico', 3, 2);
insert into Courses (course_id, course_name, branch_id, id_degree) values (16, 'Sistemas de Telecomunicaciones e Informáticos', 3, 2);
insert into Courses (course_id, course_name, branch_id, id_degree) values (17, 'Sistemas de Telecomunicaciones e Informáticos a Distancia', 3, 2);
insert into Courses (course_id, course_name, branch_id, id_degree) values (18, 'Sistemas Electrotécnicos y Automatizados', 3, 2);
insert into Courses (course_id, course_name, branch_id, id_degree) values (19, 'Sistemas Electrotécnicos y Automatizados Distancia', 3, 2);

insert into Courses (course_id, course_name, branch_id, id_degree) values (20, 'Video Disc-Jockey y Sonido', 4, 1);
insert into Courses (course_id, course_name, branch_id, id_degree) values (21, 'Producción de Audiovisuales y Espectáculos', 4, 2);
insert into Courses (course_id, course_name, branch_id, id_degree) values (22, 'Realización de Proyectos Audiovisuales y Espectáculos', 4, 2);
insert into Courses (course_id, course_name, branch_id, id_degree) values (23, 'Animaciones 3D, Juegos y Entornos Interactivos', 4, 2);
insert into Courses (course_id, course_name, branch_id, id_degree) values (24, 'Iluminación, Captación y Tratamiento de Imagen', 4, 2);

insert into Courses (course_id, course_name, branch_id, id_degree) values (25, 'Sistemas Microinformáticos y Redes', 5, 1);
insert into Courses (course_id, course_name, branch_id, id_degree) values (26, 'Sistemas Microinformáticos y Redes a Distancia', 5, 1);
insert into Courses (course_id, course_name, branch_id, id_degree) values (27, 'Administración de Sistemas Informáticos en Red', 5, 2);
insert into Courses (course_id, course_name, branch_id, id_degree) values (28, 'Administración de Sistemas Informáticos en Red a Distancia', 5, 2);
insert into Courses (course_id, course_name, branch_id, id_degree) values (29, 'Desarrollo de aplicaciones Multiplataforma', 5, 2);
insert into Courses (course_id, course_name, branch_id, id_degree) values (30, 'Desarrollo de aplicaciones Multiplataforma a Distancia', 5, 2);
insert into Courses (course_id, course_name, branch_id, id_degree) values (31, 'Desarrollo de aplicaciones Web', 5, 2);
insert into Courses (course_id, course_name, branch_id, id_degree) values (32, 'Desarrollo de aplicaciones Web a Distancia', 5, 2);
GO

-- Insert values to Students
SET DATEFORMAT dmy;
GO
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (1, 'Jonie', 'Scoble', '21/02/1986', 'Female', '20248 Walton Place', 272349069, 'jscoble0@eepurl.com', 14);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (2, 'Bary', 'Dorber', '11/05/1975', 'Male', '9 Sugar Drive', 750925233, 'bdorber1@ezinearticles.com', 16);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (3, 'Ardine', 'Decroix', '26/04/1990', 'Female', '055 Laurel Park', 498229187, 'adecroix2@admin.ch', 25);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (4, 'Dukey', 'Buxam', '07/01/1994', 'Male', '2811 Dunning Lane', 889073971, 'dbuxam3@army.mil', 8);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (5, 'Guglielma', 'Bernhart', '26/07/1985', 'Female', '00890 Farragut Trail', 119242588, 'gbernhart4@merriam-webster.com', 6);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (6, 'Ellis', 'Benkhe', '10/09/2006', 'Male', '9147 Kings Center', 721993722, 'ebenkhe5@grra.co', 20);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (7, 'Lonnie', 'Winyard', '05/12/1993', 'Male', '037 Londonderry Avenue', 658970729, 'lwinyard6@sbwire.com', 3);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (8, 'Valentia', 'Pessel', '24/04/1962', 'Female', '7841 Tennessee Lane', 536635885, 'vpessel7@elegantthemes.com', 8);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (9, 'Mariele', 'Courtier', '23/02/1986', 'Female', '719 Veith Place', 701320199, 'mcourtier8@tuttocitta.it', 11);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (10, 'Clim', 'Veronique', '12/02/1982', 'Male', '798 Sunbrook Drive', 477980746, 'cveronique9@acquirethisname.com', 16);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (11, 'Clerc', 'Waldock', '02/08/1961', 'Male', '2 8th Road', 124040574, 'cwaldocka@shinystat.com', 25);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (12, 'Jackqueline', 'Silcock', '09/03/1965', 'Female', '3625 Lillian Way', 266505062, 'jsilcockb@techcrunch.com', 22);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (13, 'Poppy', 'Edworthye', '26/09/1992', 'Female', '5 Brentwood Alley', 365282383, 'pedworthyec@issuu.com', 32);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (14, 'Milt', 'Welband', '15/10/1972', 'Male', '125 Sunfield Court', 131708259, 'mwelbandd@amazon.de', 14);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (15, 'Trevar', 'Dmych', '14/04/1991', 'Male', '3 Melrose Place', 126798804, 'tdmyche@hud.gov', 24);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (16, 'Willem', 'Lambotin', '23/02/1979', 'Male', '3464 Clarendon Alley', 680049125, 'wlambotinf@telegraph.co.uk', 8);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (17, 'Horatia', 'Prangle', '04/11/2000', 'Female', '0370 Scoville Road', 416993475, 'hprangleg@microsoft.com', 31);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (18, 'Sander', 'Huertas', '07/05/1972', 'Male', '0 Merchant Trail', 919227071, 'shuertash@arstechnica.com', 4);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (19, 'Basilius', 'Coverdill', '14/06/1972', 'Male', '841 Judy Road', 188163322, 'bcoverdilli@msn.com', 2);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (20, 'Patrice', 'Boome', '29/04/2001', 'Female', '804 Spohn Junction', 634677708, 'pboomej@ocn.ne.jp', 17);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (21, 'Kris', 'Tuft', '03/06/1970', 'Female', '184 Straubel Plaza', 298025623, 'ktuftk@gggr.co', 25);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (22, 'Ethelbert', 'Lively', '20/08/1978', 'Male', '92 Novick Way', 906343796, 'elivelyl@w3.org', 29);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (23, 'Brodie', 'Schubbert', '24/03/1962', 'Male', '39789 Sommers Parkway', 446632384, 'bschubbertm@mit.edu', 16);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (24, 'Inez', 'Stringman', '10/10/1962', 'Female', '92620 Packers Road', 851114457, 'istringmann@rakuten.co.jp', 1);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (25, 'Urban', 'O''Kinneally', '03/11/2005', 'Male', '50 Cottonwood Court', 483551550, 'uokinneallyo@cafepress.com', 9);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (26, 'Rich', 'Kighly', '27/11/1996', 'Male', '5241 Blackbird Terrace', 357881949, 'rkighlyp@bloglovin.com', 20);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (27, 'Kristyn', 'Barkas', '18/12/1971', 'Female', '2 Northridge Hill', 590919183, 'kbarkasq@bloomberg.com', 23);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (28, 'Bendick', 'Allington', '19/07/2002', 'Male', '3011 Schurz Trail', 289314826, 'ballingtonr@youku.com', 19);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (29, 'Durante', 'D''Antoni', '03/09/1993', 'Male', '5697 Miller Junction', 358434415, 'ddantonis@nytimes.com', 20);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (30, 'Coral', 'Gammade', '30/01/1981', 'Female', '49 Vernon Circle', 995316225, 'cgammadet@xinhuanet.com', 31);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (31, 'Kit', 'Grossman', '06/08/1999', 'Female', '23 Lakewood Gardens Hill', 540548335, 'kgrossmanu@si.edu', 28);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (32, 'Thibaud', 'Nan Carrow', '14/06/1998', 'Male', '9249 Shoshone Way', 264167355, 'tnancarrowv@vinaora.com', 23);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (33, 'Marwin', 'O''Sheilds', '29/06/1983', 'Male', '6 Vermont Center', 641447937, 'mosheildsw@woothemes.com', 21);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (34, 'Gun', 'Bladge', '29/03/1967', 'Male', '467 Graceland Parkway', 367313490, 'gbladgex@scientificamerican.com', 11);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (35, 'Evanne', 'Collidge', '25/12/1989', 'Female', '21275 Arapahoe Center', 747704068, 'ecollidgey@pbs.org', 16);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (36, 'Cornelia', 'Clilverd', '19/10/2000', 'Female', '772 Larry Circle', 595570161, 'cclilverdz@washingtonpost.com', 18);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (37, 'Chad', 'Taylot', '08/06/1987', 'Female', '7 Pankratz Place', 654621334, 'ctaylot10@canalblog.com', 18);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (38, 'Lorraine', 'Dimitrijevic', '24/11/1996', 'Female', '1005 Sherman Crossing', 766996458, 'ldimitrijevic11@about.com', 22);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (39, 'Kassi', 'O''Nowlan', '26/10/1996', 'Female', '1 Kim Alley', 402567830, 'konowlan12@blogger.com', 24);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (40, 'Paco', 'Edmons', '05/04/1960', 'Male', '4475 Truax Place', 139873513, 'pedmons13@storify.com', 21);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (41, 'Carey', 'Humblestone', '23/06/1960', 'Male', '4424 Pleasure Terrace', 151674380, 'chumblestone14@multiply.com', 6);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (42, 'Elwira', 'Ackerley', '14/06/1985', 'Female', '5 Goodland Center', 378739049, 'eackerley15@wufoo.com', 25);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (43, 'Guillermo', 'Trewin', '27/03/1986', 'Male', '22051 Hoffman Hill', 375065576, 'gtrewin16@de.vu', 15);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (44, 'Belicia', 'Matyas', '16/05/1989', 'Female', '3 Browning Drive', 754414781, 'bmatyas17@wisc.edu', 16);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (45, 'Lucine', 'Jeckell', '02/04/2003', 'Female', '9 Swallow Way', 998042163, 'ljeckell18@ihg.com', 30);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (46, 'Burke', 'Turner', '05/08/2002', 'Male', '50717 Fieldstone Way', 555133144, 'bturner19@usnews.com', 15);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (47, 'Avie', 'Cranmer', '26/06/1967', 'Female', '43681 La Follette Terrace', 376427775, 'acranmer1a@shop-pro.jp', 13);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (48, 'Orren', 'Carroll', '29/06/1975', 'Male', '148 Jenna Way', 678348611, 'ocarroll1b@jalbum.net', 20);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (49, 'Magnum', 'Seamons', '01/05/1966', 'Male', '7 Gulseth Plaza', 484789097, 'mseamons1c@posterous.com', 15);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (50, 'Winni', 'Yerrall', '23/02/1977', 'Female', '65041 High Crossing Junction', 589450557, 'wyerrall1d@time.com', 6);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (51, 'Ruy', 'Petru', '20/07/1995', 'Male', '92 Miller Way', 146856207, 'rpetru1e@zdnet.com', 29);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (52, 'Sue', 'Charter', '24/10/1969', 'Female', '8517 Gateway Hill', 908309848, 'scharter1f@bravesites.com', 6);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (53, 'Chandler', 'Gabites', '29/10/1987', 'Male', '9 Magdeline Center', 662424894, 'cgabites1g@infoseek.co.jp', 2);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (54, 'Jsandye', 'Cicutto', '03/12/1996', 'Female', '006 Duke Park', 806191725, 'jcicutto1h@state.tx.us', 1);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (55, 'Sigmund', 'Linacre', '31/12/2002', 'Male', '1 Oriole Way', 123138665, 'slinacre1i@creativecommons.org', 4);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (56, 'Bertrando', 'Wiersma', '12/08/1966', 'Male', '188 Old Shore Alley', 656970180, 'bwiersma1j@stanford.edu', 11);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (57, 'Eadie', 'Meas', '30/09/1962', 'Female', '0 Anderson Lane', 470133484, 'emeas1k@seesaa.net', 12);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (58, 'Barr', 'MacSharry', '24/12/1974', 'Male', '84 Dorton Way', 852905941, 'bmacsharry1l@cam.ac.uk', 8);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (59, 'Trumaine', 'Faherty', '03/01/1973', 'Male', '301 Bowman Terrace', 176887434, 'tfaherty1m@thetimes.co.uk', 28);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (60, 'Cyrillus', 'Karlicek', '12/12/1978', 'Male', '19616 Meadow Ridge Court', 892639943, 'ckarlicek1n@elegantthemes.com', 11);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (61, 'Kimmi', 'Pulteneye', '16/06/1997', 'Female', '81 Mifflin Terrace', 172714930, 'kpulteneye1o@illinois.edu', 28);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (62, 'Boigie', 'Cassley', '02/07/1966', 'Male', '0322 Thackeray Way', 470723905, 'bcassley1p@pagesperso-orange.fr', 11);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (63, 'Albrecht', 'Lushey', '27/07/1997', 'Male', '159 Mcbride Street', 618028543, 'alushey1q@ft.com', 28);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (64, 'Gerrie', 'McTerry', '22/08/1977', 'Male', '90 Vidon Trail', 156944541, 'gmcterry1r@tuttocitta.it', 17);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (65, 'Gil', 'Keyworth', '17/09/1964', 'Male', '90329 Esker Trail', 431749490, 'gkeyworth1s@clickbank.net', 19);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (66, 'Emelina', 'Ashborne', '14/11/1964', 'Female', '14 Judy Junction', 716691617, 'eashborne1t@umich.edu', 32);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (67, 'Jerrylee', 'Winsiowiecki', '23/12/1968', 'Female', '74490 2nd Road', 567598321, 'jwinsiowiecki1u@paginegialle.it', 27);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (68, 'Kathryne', 'Zute', '09/12/2005', 'Female', '039 Browning Way', 325625367, 'kzute1v@alibaba.com', 15);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (69, 'Niko', 'Beecker', '11/08/2001', 'Male', '7 Forster Way', 733950087, 'nbeecker1w@dyndns.org', 15);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (70, 'Eleanora', 'MacKeeg', '02/09/1964', 'Female', '0406 Kings Center', 371197020, 'emackeeg1x@patch.com', 6);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (71, 'Desmond', 'Lindgren', '15/04/1982', 'Male', '947 Gale Street', 912215901, 'dlindgren1y@addthis.com', 22);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (72, 'Betsey', 'Rustan', '31/08/2006', 'Female', '757 Lakewood Trail', 401036053, 'brustan1z@storify.com', 29);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (73, 'Javier', 'Lowey', '06/11/1987', 'Male', '779 Chive Junction', 264482386, 'jlowey20@auda.org.au', 8);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (74, 'Bondy', 'Newlove', '25/06/1963', 'Male', '65932 Raven Park', 705231501, 'bnewlove21@yale.edu', 14);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (75, 'Jacques', 'Hagwood', '05/12/1978', 'Male', '265 Londonderry Junction', 906777091, 'jhagwood22@archive.org', 30);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (76, 'Dorothea', 'Bangley', '14/10/1980', 'Female', '78177 Summerview Place', 461657625, 'dbangley23@shutterfly.com', 25);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (77, 'Lira', 'Devany', '03/09/1996', 'Female', '61379 Dexter Terrace', 300275554, 'ldevany24@newsvine.com', 4);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (78, 'Korie', 'McEttigen', '07/07/2005', 'Female', '1814 Springs Alley', 983346895, 'kmcettigen25@t-online.de', 3);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (79, 'Rafaela', 'Nisby', '21/07/1965', 'Female', '5035 Vera Way', 821600816, 'rnisby26@prlog.org', 7);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (80, 'Georgeanna', 'Bynold', '19/07/1980', 'Female', '5 Lawn Street', 147533340, 'gbynold27@hhs.gov', 3);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (81, 'Genvieve', 'Pettie', '27/01/1965', 'Female', '37 Evergreen Way', 108218665, 'gpettie28@blogtalkradio.com', 10);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (82, 'Rubetta', 'Gabitis', '13/02/1976', 'Female', '61155 Farwell Center', 782985097, 'rgabitis29@hp.com', 22);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (83, 'Michele', 'Lemm', '09/04/1973', 'Female', '503 Moulton Lane', 844683925, 'mlemm2a@canalblog.com', 21);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (84, 'Sheppard', 'Schapiro', '25/01/1973', 'Male', '4321 Dexter Street', 963285722, 'sschapiro2b@youtu.be', 24);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (85, 'Robinetta', 'Powers', '17/07/1983', 'Female', '372 Mayfield Court', 315732709, 'rpowers2c@epa.gov', 25);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (86, 'Addie', 'Coggings', '13/03/1986', 'Male', '9890 Oriole Drive', 124483688, 'acoggings2d@php.net', 1);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (87, 'Boycey', 'Hilley', '09/12/2006', 'Male', '52 Blaine Plaza', 745535015, 'bhilley2e@com.com', 10);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (88, 'Xever', 'MacCurlye', '23/03/1987', 'Male', '53 Northport Trail', 175635556, 'xmaccurlye2f@lycos.com', 18);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (89, 'Everett', 'Belton', '25/02/1978', 'Male', '967 Dwight Place', 544431907, 'ebelton2g@a8.net', 32);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (90, 'Billie', 'Scraney', '25/10/1993', 'Female', '3 John Wall Junction', 192757754, 'bscraney2h@symantec.com', 10);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (91, 'Nataniel', 'Eliff', '04/02/1968', 'Male', '9 Pankratz Crossing', 261317525, 'neliff2i@networksolutions.com', 25);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (92, 'Jamal', 'Brotherton', '25/02/1998', 'Male', '20127 Carpenter Place', 468433145, 'jbrotherton2j@typepad.com', 32);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (93, 'Hillier', 'McLeese', '27/05/1993', 'Male', '87845 Kenwood Parkway', 958958228, 'hmcleese2k@freewebs.com', 24);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (94, 'Ketty', 'Bracchi', '20/05/1993', 'Female', '17 Independence Way', 745738244, 'kbracchi2l@yale.edu', 5);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (95, 'Genia', 'Patrono', '04/01/2002', 'Female', '4 Moland Way', 655029828, 'gpatrono2m@prweb.com', 8);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (96, 'Dulcia', 'Alkins', '23/09/1978', 'Female', '610 Ludington Circle', 483509555, 'dalkins2n@oaic.gov.au', 18);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (97, 'Cass', 'Geharke', '11/08/1972', 'Female', '38947 Cascade Junction', 950906042, 'cgeharke2o@yolasite.com', 22);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (98, 'Isabella', 'Roloff', '20/05/1989', 'Female', '808 Twin Pines Parkway', 411550808, 'iroloff2p@globo.com', 9);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (99, 'Pebrook', 'Leeke', '17/09/1991', 'Male', '6820 Maple Wood Way', 898421195, 'pleeke2q@mashable.com', 26);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (100, 'Dex', 'Enga', '27/12/1996', 'Male', '8366 Barnett Junction', 203482541, 'denga2r@squidoo.com', 27);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (101, 'Glenn', 'Falla', '26/03/1999', 'Male', '1509 Loeprich Terrace', 898256401, 'gfalla2s@facebook.com', 3);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (102, 'Susann', 'Burcher', '03/07/1968', 'Female', '62582 Basil Street', 540941494, 'sburcher2t@yahoo.co.jp', 22);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (103, 'Armin', 'Lidstone', '16/11/2005', 'Male', '59 Crowley Crossing', 242238193, 'alidstone2u@japanpost.jp', 29);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (104, 'Rosalinda', 'Standish', '03/07/1968', 'Female', '20 Dwight Street', 254630377, 'rstandish2v@icq.com', 14);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (105, 'Griselda', 'Birds', '24/12/1977', 'Female', '75 Cascade Center', 560079475, 'gbirds2w@ed.gov', 3);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (106, 'Urson', 'Brimner', '07/02/1960', 'Male', '5 Forest Road', 176381352, 'ubrimner2x@ted.com', 2);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (107, 'Magdalen', 'Morant', '25/08/2000', 'Female', '414 Debra Pass', 760577891, 'mmorant2y@webmd.com', 5);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (108, 'Amara', 'Potter', '05/11/1973', 'Female', '41096 Scoville Drive', 632395633, 'apotter2z@free.fr', 21);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (109, 'Audrey', 'Dalyiel', '12/02/1972', 'Female', '65297 Westerfield Crossing', 539159979, 'adalyiel30@nbcnews.com', 28);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (110, 'Phillipe', 'Hutcheons', '08/05/1991', 'Male', '2 Dryden Lane', 503100539, 'phutcheons31@nydailynews.com', 32);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (111, 'Wanids', 'Godmer', '29/10/2000', 'Female', '3150 Maple Wood Terrace', 286078785, 'wgodmer32@shutterfly.com', 31);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (112, 'Thacher', 'Brezlaw', '08/05/1973', 'Male', '6316 Harbort Road', 950858002, 'tbrezlaw33@whitehouse.gov', 2);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (113, 'Cairistiona', 'Orthmann', '11/12/1998', 'Female', '4284 Morning Center', 562793374, 'corthmann34@ebay.co.uk', 23);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (114, 'Madel', 'Jan', '27/05/1973', 'Female', '906 Continental Crossing', 247132603, 'mjan35@buzzfeed.com', 2);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (115, 'Elnora', 'Poleye', '30/03/1965', 'Female', '45 Barby Way', 203149125, 'epoleye36@vimeo.com', 22);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (116, 'Denys', 'Izak', '11/02/1974', 'Male', '30 Orin Hill', 843263116, 'dizak37@google.com.hk', 9);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (117, 'Lyn', 'MacFadzan', '04/04/1960', 'Male', '5668 Prairie Rose Avenue', 842491152, 'lmacfadzan38@deviantart.com', 9);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (118, 'Winni', 'Karpf', '28/10/1972', 'Female', '8882 Grasskamp Junction', 214566278, 'wkarpf39@disqus.com', 16);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (119, 'Conrado', 'Waycott', '13/07/1987', 'Male', '3 Bartelt Alley', 905391505, 'cwaycott3a@who.int', 9);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (120, 'Kristofer', 'Warlton', '04/03/2005', 'Male', '981 Ronald Regan Parkway', 997099880, 'kwarlton3b@bizjournals.com', 5);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (121, 'Druci', 'Stoacley', '02/11/1971', 'Female', '14601 Shoshone Parkway', 333981668, 'dstoacley3c@uol.com.br', 3);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (122, 'Zarla', 'Toppin', '26/10/2006', 'Female', '38 Clyde Gallagher Park', 983976707, 'ztoppin3d@hud.gov', 12);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (123, 'Ward', 'Abrahamson', '28/06/1989', 'Male', '194 Manufacturers Trail', 467558519, 'wabrahamson3e@behance.net', 4);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (124, 'Livy', 'Schule', '10/06/1961', 'Female', '710 Carioca Trail', 390185936, 'lschule3f@bloglovin.com', 7);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (125, 'Mandi', 'Terbruggen', '24/04/1990', 'Female', '350 Holy Cross Alley', 573977909, 'mterbruggen3g@icq.com', 11);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (126, 'Orv', 'Lightowlers', '20/02/2000', 'Male', '89 Basil Hill', 347496768, 'olightowlers3h@hostgator.com', 7);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (127, 'Kris', 'Circuitt', '21/03/1991', 'Male', '714 Petterle Drive', 201014242, 'kcircuitt3i@webnode.com', 29);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (128, 'Geoffry', 'Trayton', '02/09/2001', 'Male', '31090 Westend Trail', 382705624, 'gtrayton3j@histats.com', 14);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (129, 'Korry', 'Anetts', '21/11/1990', 'Female', '9382 Karstens Trail', 902736510, 'kanetts3k@state.gov', 3);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (130, 'Giffard', 'Atyea', '12/12/1984', 'Male', '765 Kim Center', 872262490, 'gatyea3l@1688.com', 30);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (131, 'Goraud', 'Brumwell', '15/09/2004', 'Male', '2972 Glacier Hill Pass', 926186662, 'gbrumwell3m@google.com.br', 24);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (132, 'Mick', 'Gannicott', '28/10/1967', 'Male', '53637 Cherokee Terrace', 685741768, 'mgannicott3n@bloglines.com', 8);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (133, 'Eilis', 'Schumacher', '17/02/1965', 'Female', '94 Granby Park', 520840012, 'eschumacher3o@cbsnews.com', 32);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (134, 'Lynnet', 'Jephson', '16/06/2002', 'Female', '21 Ronald Regan Way', 550914746, 'ljephson3p@npr.org', 3);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (135, 'Cristal', 'Polden', '16/11/1991', 'Female', '2 Hanson Alley', 984012883, 'cpolden3q@timesonline.co.uk', 6);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (136, 'Harley', 'Misselbrook', '23/03/1960', 'Male', '72 Elmside Center', 120701032, 'hmisselbrook3r@omniture.com', 6);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (137, 'Yance', 'Surridge', '20/03/2003', 'Male', '26 Arkansas Road', 696669227, 'ysurridge3s@360.cn', 7);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (138, 'Bette', 'Trevaskis', '24/03/1991', 'Female', '00 Corscot Center', 144180110, 'btrevaskis3t@google.de', 10);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (139, 'Elliott', 'Budgeon', '01/09/1997', 'Male', '04151 Cherokee Park', 642234064, 'ebudgeon3u@360.cn', 30);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (140, 'Lois', 'Hovey', '29/11/1975', 'Female', '191 Springs Place', 242516733, 'lhovey3v@kickstarter.com', 11);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (141, 'Aron', 'Brothers', '24/08/1997', 'Male', '50 Elka Junction', 207191152, 'abrothers3w@ehow.com', 23);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (142, 'Even', 'Huskisson', '25/10/2001', 'Male', '9762 Gina Pass', 588553601, 'ehuskisson3x@bigcartel.com', 6);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (143, 'Teodor', 'McKay', '17/10/1992', 'Male', '0 Prairieview Way', 448055201, 'tmckay3y@canalblog.com', 5);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (144, 'Zabrina', 'Smallridge', '02/12/1981', 'Female', '9 North Parkway', 908637488, 'zsmallridge3z@answers.com', 25);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (145, 'Dalis', 'Imms', '27/01/2003', 'Male', '5941 Johnson Park', 461933560, 'dimms40@nydailynews.com', 2);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (146, 'Jard', 'Morey', '12/05/1968', 'Male', '405 Emmet Street', 213540287, 'jmorey41@nationalgeographic.com', 25);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (147, 'Tiphany', 'Espinho', '18/08/1984', 'Female', '88 Vera Point', 659116626, 'tespinho42@ow.ly', 24);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (148, 'Gerhardine', 'Silkstone', '29/08/1976', 'Female', '62349 Hansons Hill', 486124431, 'gsilkstone43@cyberchimps.com', 6);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (149, 'Justin', 'Northcott', '10/04/1968', 'Male', '268 Muir Point', 994444855, 'jnorthcott44@sogou.com', 4);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (150, 'Didi', 'Vidyapin', '08/07/1994', 'Female', '57879 Westridge Parkway', 133410160, 'dvidyapin45@hibu.com', 2);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (151, 'Rusty', 'Glabach', '25/11/1994', 'Male', '77740 Ramsey Trail', 198936807, 'rglabach46@webeden.co.uk', 1);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (152, 'Sheree', 'Tschirschky', '01/12/1986', 'Female', '6971 Portage Drive', 407756989, 'stschirschky47@barnesandnoble.com', 24);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (153, 'Abe', 'Going', '20/02/2007', 'Male', '44572 Sachtjen Road', 632346482, 'agoing48@springer.com', 29);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (154, 'Barret', 'Carass', '15/05/1963', 'Male', '4591 Steensland Terrace', 187346812, 'bcarass49@wordpress.com', 18);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (155, 'Kristin', 'Phorsby', '03/10/1974', 'Female', '45 Vernon Court', 417469536, 'kphorsby4a@thetimes.co.uk', 7);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (156, 'Yves', 'Careless', '13/08/1966', 'Male', '5 Dennis Center', 645756789, 'ycareless4b@huffingtonpost.com', 26);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (157, 'Gretta', 'Eynon', '11/07/1981', 'Female', '965 Atwood Center', 506248567, 'geynon4c@creativecommons.org', 13);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (158, 'Bert', 'Piercy', '26/09/1988', 'Male', '442 Stone Corner Way', 621035281, 'bpiercy4d@yahoo.com', 22);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (159, 'Thain', 'Banisch', '20/06/1991', 'Male', '5024 Thackeray Way', 559316839, 'tbanisch4e@storify.com', 17);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (160, 'Tedmund', 'Rizzo', '07/09/1993', 'Male', '7445 Declaration Street', 387203253, 'trizzo4f@aol.com', 5);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (161, 'Sherilyn', 'Scard', '24/07/1994', 'Female', '48000 Barby Hill', 558030684, 'sscard4g@t-online.de', 22);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (162, 'Theodore', 'Millbank', '21/09/2000', 'Male', '3613 Texas Center', 966274171, 'tmillbank4h@over-blog.com', 23);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (163, 'Tiphani', 'Leneve', '12/08/1963', 'Female', '1 Evergreen Crossing', 724948637, 'tleneve4i@senate.gov', 2);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (164, 'Hailey', 'Pinnegar', '08/07/1985', 'Male', '30 Marcy Place', 566959582, 'hpinnegar4j@microsoft.com', 8);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (165, 'Debbi', 'Meigh', '03/01/2001', 'Female', '3 Linden Place', 766266739, 'dmeigh4k@disqus.com', 2);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (166, 'Kirbee', 'Wooster', '13/12/1963', 'Female', '1 Thackeray Place', 334350953, 'kwooster4l@skyrock.com', 16);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (167, 'Corby', 'Fearn', '28/09/2004', 'Male', '61414 Cherokee Place', 762859655, 'cfearn4m@simplemachines.org', 25);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (168, 'Kristyn', 'Bastable', '30/05/1979', 'Female', '33 Hudson Drive', 448424640, 'kbastable4n@bizjournals.com', 2);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (169, 'Obadiah', 'Happel', '18/04/1999', 'Male', '87 Linden Pass', 331740019, 'ohappel4o@ow.ly', 22);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (170, 'Carmelina', 'Pollen', '03/06/1980', 'Female', '3 Myrtle Drive', 522310448, 'cpollen4p@tinypic.com', 17);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (171, 'Giffer', 'Burkart', '07/10/1969', 'Male', '1 Homewood Parkway', 583984693, 'gburkart4q@over-blog.com', 26);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (172, 'Lilllie', 'Pringer', '10/09/1999', 'Female', '0 Chive Park', 719472345, 'lpringer4r@eepurl.com', 14);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (173, 'Ellen', 'Case', '14/10/1999', 'Female', '4 Loomis Court', 250800247, 'ecase4s@tmall.com', 24);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (174, 'Silvester', 'Cana', '06/02/1998', 'Male', '01880 Oxford Trail', 309845773, 'scana4t@etsy.com', 6);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (175, 'Tabbatha', 'Benard', '29/08/1964', 'Female', '96569 Sloan Place', 233025345, 'tbenard4u@umn.edu', 5);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (176, 'Aggy', 'Tulloch', '26/07/1960', 'Female', '2881 Saint Paul Plaza', 261863609, 'atulloch4v@nationalgeographic.com', 23);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (177, 'Alphonso', 'Instone', '16/02/1964', 'Male', '797 Hagan Parkway', 562062716, 'ainstone4w@amazon.co.jp', 25);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (178, 'Hakeem', 'Lorie', '27/05/1986', 'Male', '2 High Crossing Parkway', 760705326, 'hlorie4x@pbs.org', 15);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (179, 'Alida', 'Helliar', '01/01/1998', 'Female', '00007 Sugar Court', 413429557, 'ahelliar4y@goodreads.com', 15);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (180, 'Konstanze', 'Minchi', '26/11/2001', 'Female', '219 Weeping Birch Park', 775023559, 'kminchi4z@house.gov', 5);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (181, 'Dix', 'Sapson', '15/03/1972', 'Female', '409 Katie Lane', 204665866, 'dsapson50@nydailynews.com', 19);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (182, 'Margaretta', 'Jurick', '09/03/1976', 'Female', '29 Dennis Hill', 170142755, 'mjurick51@cloudflare.com', 12);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (183, 'Lorette', 'Orviss', '19/07/1978', 'Female', '0 Anniversary Hill', 289583119, 'lorviss52@craigslist.org', 6);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (184, 'Cleve', 'Malletratt', '14/01/1963', 'Male', '2905 Holy Cross Court', 971805766, 'cmalletratt53@soup.io', 15);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (185, 'Gae', 'Coraini', '07/07/1981', 'Female', '2 3rd Junction', 904664126, 'gcoraini54@ucoz.ru', 12);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (186, 'Jacqui', 'Woof', '16/12/1984', 'Female', '5733 Fulton Road', 510285846, 'jwoof55@xinhuanet.com', 23);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (187, 'Perren', 'Floris', '30/12/1983', 'Male', '655 Autumn Leaf Place', 251484307, 'pfloris56@go.com', 2);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (188, 'Rayshell', 'Meneer', '09/11/1988', 'Female', '291 Jay Avenue', 444606872, 'rmeneer57@purevolume.com', 26);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (189, 'Thorstein', 'Josskoviz', '24/03/1981', 'Male', '74 Hudson Circle', 392981065, 'tjosskoviz58@ucoz.ru', 12);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (190, 'Dav', 'Denman', '21/01/1975', 'Male', '26 5th Street', 551909672, 'ddenman59@gizmodo.com', 26);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (191, 'Cammy', 'Finden', '19/10/1972', 'Male', '315 Orin Place', 569855410, 'cfinden5a@wikia.com', 10);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (192, 'Nathalie', 'Issacoff', '13/06/1988', 'Female', '7801 Roxbury Trail', 584637534, 'nissacoff5b@icq.com', 8);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (193, 'Izak', 'Bollands', '08/12/1975', 'Male', '516 Crescent Oaks Terrace', 819433320, 'ibollands5c@miibeian.gov.cn', 13);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (194, 'Avie', 'Pates', '14/07/1982', 'Female', '22 Village Park', 476551603, 'apates5d@tripod.com', 16);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (195, 'Travus', 'Brocklehurst', '01/04/1983', 'Male', '36 Badeau Crossing', 983611785, 'tbrocklehurst5e@bbc.co.uk', 32);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (196, 'Brandy', 'Sharratt', '09/05/1999', 'Male', '36139 Swallow Court', 466839095, 'bsharratt5f@cloudflare.com', 9);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (197, 'Wendi', 'Ashard', '19/10/2002', 'Female', '99 Sycamore Point', 254717102, 'washard5g@ca.gov', 31);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (198, 'Liana', 'Serotsky', '12/04/1975', 'Female', '09897 Ruskin Center', 699142362, 'lserotsky5h@tripadvisor.com', 11);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (199, 'Wilbur', 'Newlan', '06/01/1981', 'Male', '05746 Grover Parkway', 103173267, 'wnewlan5i@alexa.com', 20);
insert into Students (student_id, first_name, last_name, date_of_birth, gender, address, contact_number, email, course_id) values (200, 'Kaycee', 'Reilingen', '05/11/1965', 'Female', '4 Eliot Place', 301350419, 'kreilingen5j@indiatimes.com', 1);
GO

-- Insert values to Subjects
-- Gestión Administrativa y a distancia
insert into Subjects (subject_id, subject_name) values (1, 'Comunicación empresarial y atención al cliente');
insert into Subjects (subject_id, subject_name) values (2, 'Operaciones administrativas de compra-venta');
insert into Subjects (subject_id, subject_name) values (3, 'Empresa y Administración');
insert into Subjects (subject_id, subject_name) values (4, 'Tratamiento informático de la información');
insert into Subjects (subject_id, subject_name) values (5, 'Técnica contable');
insert into Subjects (subject_id, subject_name) values (6, 'Operaciones administrativas de recursos humanos');
insert into Subjects (subject_id, subject_name) values (7, 'Tratamiento de la documentación contable');
insert into Subjects (subject_id, subject_name) values (8, 'Inglés');
insert into Subjects (subject_id, subject_name) values (9, 'Empresa en el aula');
insert into Subjects (subject_id, subject_name) values (10, 'Operaciones auxiliares de gestión de tesorería');
insert into Subjects (subject_id, subject_name) values (11, 'Formación y orientación laboral');
insert into Subjects (subject_id, subject_name) values (12, 'Formación en centros de trabajo');
-- Actividades Comerciales
insert into Subjects (subject_id, subject_name) values (13, 'Marketing en la actividad comercial');
insert into Subjects (subject_id, subject_name) values (14, 'Gestión de un pequeño comercio');
insert into Subjects (subject_id, subject_name) values (15, 'Técnicas de almacén');
insert into Subjects (subject_id, subject_name) values (16, 'Gestión de compras');
insert into Subjects (subject_id, subject_name) values (17, 'Venta técnica');
insert into Subjects (subject_id, subject_name) values (18, 'Dinamización del punto de venta');
insert into Subjects (subject_id, subject_name) values (19, 'Procesos de venta');
insert into Subjects (subject_id, subject_name) values (20, 'Aplicaciones informáticas para el comercio');
insert into Subjects (subject_id, subject_name) values (21, 'Servicios de atención comercial');
insert into Subjects (subject_id, subject_name) values (22, 'Comercio electrónico');
-- Instalaciones Eléctricas y Automáticas
insert into Subjects (subject_id, subject_name) values (23, 'Automatismos industriales');
insert into Subjects (subject_id, subject_name) values (24, 'Electrónica');
insert into Subjects (subject_id, subject_name) values (25, 'Electrotecnia');
insert into Subjects (subject_id, subject_name) values (26, 'Instalaciones eléctricas interiores');
insert into Subjects (subject_id, subject_name) values (27, 'Instalaciones de distribución');

insert into Subjects (subject_id, subject_name) values (28, 'Infraestructuras comunes de telecomunicación en viviendas y edificios');
insert into Subjects (subject_id, subject_name) values (29, 'Instalaciones domóticas');
insert into Subjects (subject_id, subject_name) values (30, 'Instalaciones solares fotovoltaicas');
-- Instalaciones de TeleComunicaciones tambien
insert into Subjects (subject_id, subject_name) values (31, 'Máquinas eléctricas');
-- Instalaciones de TeleComunicaciones
insert into Subjects (subject_id, subject_name) values (32, 'Equipos microinformáticos');
insert into Subjects (subject_id, subject_name) values (33, 'Infraestructuras de redes de datos y sistemas de telefonía');
insert into Subjects (subject_id, subject_name) values (34, 'Instalaciones eléctricas básicas');
insert into Subjects (subject_id, subject_name) values (35, 'Instalaciones de megafonía y sonorización');
insert into Subjects (subject_id, subject_name) values (36, 'Circuito cerrado de televisión y seguridad electrónica');
insert into Subjects (subject_id, subject_name) values (37, 'Instalaciones de radiocomunicaciones');
-- Video Disc-Jockey y Sonido
insert into Subjects (subject_id, subject_name) values (38, 'Instalación y montaje de equipos de sonido');
insert into Subjects (subject_id, subject_name) values (39, 'Captación y grabación de sonido');
insert into Subjects (subject_id, subject_name) values (40, 'Control, edición y mezcla de sonido');
insert into Subjects (subject_id, subject_name) values (41, 'Preparación de sesiones de vídeo disc-jockey');
insert into Subjects (subject_id, subject_name) values (42, 'Animación musical en vivo');
insert into Subjects (subject_id, subject_name) values (43, 'Animación visual en vivo');
insert into Subjects (subject_id, subject_name) values (44, 'Toma y edición digital de imagen');
-- Sistemas Microinformáticos y Redes y Distancia
insert into Subjects (subject_id, subject_name) values (45, 'Montaje y mantenimiento de equipo');
insert into Subjects (subject_id, subject_name) values (46, 'Sistemas operativos monopuesto');
insert into Subjects (subject_id, subject_name) values (47, 'Aplicaciones ofimáticas');
insert into Subjects (subject_id, subject_name) values (48, 'Sistemas operativos en red');
insert into Subjects (subject_id, subject_name) values (49, 'Redes locales');
insert into Subjects (subject_id, subject_name) values (50, 'Seguridad informática');
insert into Subjects (subject_id, subject_name) values (51, 'Servicios en red');
insert into Subjects (subject_id, subject_name) values (52, 'Aplicaciones web');
-- Grado superior
-- Administración y Finanzas y Distancia
insert into Subjects (subject_id, subject_name) values (53, 'Gestión de la documentación jurídica y empresarial');
insert into Subjects (subject_id, subject_name) values (54, 'Recursos humanos y responsabilidad social corporativa');
insert into Subjects (subject_id, subject_name) values (55, 'Ofimática y proceso de la información');
insert into Subjects (subject_id, subject_name) values (56, 'Ofimática y proceso de la informaciónl');
insert into Subjects (subject_id, subject_name) values (57, 'Comunicación y atención al cliente');
-- Aqui arriba tambien Asistencia a la Dirección y Distancia
insert into Subjects (subject_id, subject_name) values (58, 'Gestión de recursos humanos');
insert into Subjects (subject_id, subject_name) values (59, 'Gestión financiera');
insert into Subjects (subject_id, subject_name) values (60, 'Contabilidad y fiscalidad');
insert into Subjects (subject_id, subject_name) values (61, 'Gestión logística y comercial');
insert into Subjects (subject_id, subject_name) values (62, 'Simulación empresarial');
insert into Subjects (subject_id, subject_name) values (63, 'Proyecto de administración y finanzas');
-- Asistencia a la Dirección y Distancia
insert into Subjects (subject_id, subject_name) values (64, 'Segunda lengua extranjera');
insert into Subjects (subject_id, subject_name) values (65, 'Protocolo empresarial');
insert into Subjects (subject_id, subject_name) values (66, 'Organización de eventos empresariales');
insert into Subjects (subject_id, subject_name) values (67, 'Gestión avanzada de la información');
insert into Subjects (subject_id, subject_name) values (68, 'Proyecto de asistencia a la dirección');
-- COMERCIO Y MARKETING
-- Comercio Internacional y Distancia

insert into Subjects (subject_id, subject_name) values (69, 'Gestión económica y financiera de la empresa');
-- Gestión de Ventas y Espacios Comerciales, Marketing y Publicidad, Transporte y Logística tambien
insert into Subjects (subject_id, subject_name) values (70, 'Sistema de información de mercados');
insert into Subjects (subject_id, subject_name) values (71, 'Marketing internacional');
insert into Subjects (subject_id, subject_name) values (72, 'Negociación internacional');

insert into Subjects (subject_id, subject_name) values (73, 'Gestión administrativa del comercio internacional');
-- Transporte y Logística tambien
insert into Subjects (subject_id, subject_name) values (74, 'Financiación internacional');

insert into Subjects (subject_id, subject_name) values (75, 'Logística de almacenamiento');
-- Gestión de Ventas y Espacios Comerciales, Transporte y Logística tambien

insert into Subjects (subject_id, subject_name) values (76, 'Transporte internacional de mercancías');
-- Transporte y Logística tambien
insert into Subjects (subject_id, subject_name) values (77, 'Medios de pago internacionales');
insert into Subjects (subject_id, subject_name) values (78, 'Comercio digital internacional');
insert into Subjects (subject_id, subject_name) values (79, 'Proyecto de comercio internacional');
-- Gestión de Ventas y Espacios Comerciales
insert into Subjects (subject_id, subject_name) values (80, 'Escaparatismo y diseño de espacios comerciales');
insert into Subjects (subject_id, subject_name) values (81, 'Gestión de productos y promociones en el punto de venta');
insert into Subjects (subject_id, subject_name) values (82, 'Organización de equipos de ventas');
insert into Subjects (subject_id, subject_name) values (83, 'Técnicas de venta y negociación');

insert into Subjects (subject_id, subject_name) values (84, 'Políticas de marketing');
-- Marketing y Publicidad tambien
insert into Subjects (subject_id, subject_name) values (85, 'Investigación comercial');

insert into Subjects (subject_id, subject_name) values (86, 'Marketing digital');
-- Marketing y Publicidad tambien

insert into Subjects (subject_id, subject_name) values (87, 'Logística de aprovisionamiento');
-- Transporte y Logística tambien
insert into Subjects (subject_id, subject_name) values (88, 'Proyecto de gestión de ventas y espacios comerciales');
-- Marketing y Publicidad
insert into Subjects (subject_id, subject_name) values (89, 'Marketing y Publicidad');
insert into Subjects (subject_id, subject_name) values (90, 'Trabajo de campo en la investigación comercial');
insert into Subjects (subject_id, subject_name) values (91, 'Lanzamiento de productos y servicios');
insert into Subjects (subject_id, subject_name) values (92, 'Medios y soportes de comunicación');
insert into Subjects (subject_id, subject_name) values (93, 'Atención al cliente, consumidor y usuario');
insert into Subjects (subject_id, subject_name) values (94, 'Diseño y elaboración de material de comunicación');
insert into Subjects (subject_id, subject_name) values (95, 'Relaciones Públicas y organización de eventos de marketing');
insert into Subjects (subject_id, subject_name) values (96, 'Proyecto de marketing y publicidad');
-- Transporte y Logística
insert into Subjects (subject_id, subject_name) values (97, 'Gestión administrativa del transporte y la logística');
insert into Subjects (subject_id, subject_name) values (98, 'Comercialización del transporte y la logística');
insert into Subjects (subject_id, subject_name) values (99, 'Organización del transporte de viajeros');
insert into Subjects (subject_id, subject_name) values (100, 'Organización del transporte de mercancías');
insert into Subjects (subject_id, subject_name) values (101, 'Proyecto de logística y transporte');
-- Electricidad y electronica
-- Mantenimiento Electrónico
insert into Subjects (subject_id, subject_name) values (102, 'Circuitos electrónicos analógicos');
insert into Subjects (subject_id, subject_name) values (103, 'Equipos microprogramables');
insert into Subjects (subject_id, subject_name) values (104, 'Mantenimiento de equipos de radiocomunicaciones');
insert into Subjects (subject_id, subject_name) values (105, 'Mantenimiento de equipos de voz y datos');
insert into Subjects (subject_id, subject_name) values (106, 'Mantenimiento de equipos de electrónica industrial');
insert into Subjects (subject_id, subject_name) values (107, 'Mantenimiento de equipos de audio');
insert into Subjects (subject_id, subject_name) values (108, 'Mantenimiento de equipos de vídeo');
insert into Subjects (subject_id, subject_name) values (109, 'Técnicas y procesos de montaje y mantenimiento de equipos electrónicos');
insert into Subjects (subject_id, subject_name) values (110, 'Infraestructuras y desarrollo del mantenimiento electrónico');
insert into Subjects (subject_id, subject_name) values (111, 'Proyecto de mantenimiento electrónico');
-- Sistemas de Telecomunicaciones e Informáticos y Distancia
insert into Subjects (subject_id, subject_name) values (112, 'Configuración de infraestructuras de sistemas de telecomunicaciones');
insert into Subjects (subject_id, subject_name) values (113, 'Elementos de sistemas de telecomunicaciones');
insert into Subjects (subject_id, subject_name) values (114, 'Sistemas informáticos y redes locales');
insert into Subjects (subject_id, subject_name) values (115, 'Técnicas y procesos en infraestructuras de telecomunicaciones');
insert into Subjects (subject_id, subject_name) values (116, 'Sistemas de producción audiovisual');
insert into Subjects (subject_id, subject_name) values (117, 'Redes telemáticas');
insert into Subjects (subject_id, subject_name) values (118, 'Sistemas de radiocomunicaciones');
insert into Subjects (subject_id, subject_name) values (119, 'Sistemas integrados y hogar digital');
insert into Subjects (subject_id, subject_name) values (120, 'Gestión de proyectos de instalaciones de telecomunicaciones');
insert into Subjects (subject_id, subject_name) values (121, 'Sistemas de telefonía fija y móvil');
insert into Subjects (subject_id, subject_name) values (122, 'Proyecto de sistemas de telecomunicaciones e informáticos');
-- Sistemas Electrotécnicos y Automatizados y Distancia
insert into Subjects (subject_id, subject_name) values (123, 'Procesos en instalaciones de infraestructuras comunes de telecomunicaciones');
insert into Subjects (subject_id, subject_name) values (124, 'Técnicas y procesos en instalaciones eléctricas');
insert into Subjects (subject_id, subject_name) values (125, 'Documentación técnica en instalaciones eléctricas');
insert into Subjects (subject_id, subject_name) values (126, 'Sistemas y circuitos eléctricos');
insert into Subjects (subject_id, subject_name) values (127, 'Técnicas y procesos en instalaciones domóticas y automáticas');
insert into Subjects (subject_id, subject_name) values (128, 'Desarrollo de redes eléctricas y centros de transformación');
insert into Subjects (subject_id, subject_name) values (129, 'Configuración de instalaciones domóticas y automáticas');
insert into Subjects (subject_id, subject_name) values (130, 'Configuración de instalaciones eléctricas');
insert into Subjects (subject_id, subject_name) values (131, 'Gestión del montaje y del mantenimiento de instalaciones eléctricas');
insert into Subjects (subject_id, subject_name) values (132, 'Proyecto de sistemas electrotécnicos y automatizados');
-- Imagen y sonido
-- Producción de Audiovisuales y Espectáculos
insert into Subjects (subject_id, subject_name) values (133, 'Planificación de proyectos audiovisuales');
insert into Subjects (subject_id, subject_name) values (134, 'Gestión de proyectos de cine, vídeo y multimedia');
insert into Subjects (subject_id, subject_name) values (135, 'Gestión de proyectos de televisión y radio');
insert into Subjects (subject_id, subject_name) values (136, 'Planificación de proyectos de espectáculos y eventos');
insert into Subjects (subject_id, subject_name) values (137, 'Gestión de proyectos de espectáculos y eventos');
insert into Subjects (subject_id, subject_name) values (138, 'Recursos expresivos audiovisuales y escénicos');
insert into Subjects (subject_id, subject_name) values (139, 'Medios técnicos audiovisuales y escénicos');
insert into Subjects (subject_id, subject_name) values (140, 'Administración y promoción de audiovisuales y espectáculos');
insert into Subjects (subject_id, subject_name) values (141, 'Proyecto de producción de audiovisuales y espectáculos');
-- Realización de Proyectos Audiovisuales y Espectáculos
insert into Subjects (subject_id, subject_name) values (142, 'Planificación de la realización en cine y vídeo');
insert into Subjects (subject_id, subject_name) values (143, 'Procesos de realización en cine y vídeo');
insert into Subjects (subject_id, subject_name) values (144, 'Planificación de la realización en televisión');
insert into Subjects (subject_id, subject_name) values (145, 'Procesos de realización en televisión');
insert into Subjects (subject_id, subject_name) values (146, 'Planificación del montaje y postproducción de audiovisuales');

insert into Subjects (subject_id, subject_name) values (147, 'Realización del montaje y postproducción de audiovisuales');
-- Animaciones 3D, Juegos y Entornos Interactivos tambien
insert into Subjects (subject_id, subject_name) values (148, 'Planificación de la regiduría de espectáculos y eventos');
insert into Subjects (subject_id, subject_name) values (149, 'Procesos de regiduría de espectáculos y eventos');
insert into Subjects (subject_id, subject_name) values (150, 'Medios técnicos audiovisuales y escénicos en Espectáculos');
insert into Subjects (subject_id, subject_name) values (151, 'Proyecto de realización de proyectos de audiovisuales y espectáculos');
-- Animaciones 3D, Juegos y Entornos Interactivos
insert into Subjects (subject_id, subject_name) values (152, 'Proyectos de animación audiovisual 2D y 3D');
insert into Subjects (subject_id, subject_name) values (153, 'Diseño, dibujo y modelado para animación');
insert into Subjects (subject_id, subject_name) values (154, 'Animación de elementos 2D y 3D');
insert into Subjects (subject_id, subject_name) values (155, 'Color, iluminación y acabados 2D y 3D');
insert into Subjects (subject_id, subject_name) values (156, 'Proyectos de juegos y entornos interactivos');
insert into Subjects (subject_id, subject_name) values (157, 'Realización de proyectos multimedia interactivos');
insert into Subjects (subject_id, subject_name) values (158, 'Desarrollo de entornos interactivos multidispositivo');
insert into Subjects (subject_id, subject_name) values (159, 'Proyecto de Animaciones 3D, Juegos y entornos interactivos');
-- Iluminación, Captación y Tratamiento de Imagen
insert into Subjects (subject_id, subject_name) values (160, 'Planificación de cámara en audiovisuales');
insert into Subjects (subject_id, subject_name) values (161, 'Toma de imagen audiovisual');
insert into Subjects (subject_id, subject_name) values (162, 'Proyectos de iluminación');
insert into Subjects (subject_id, subject_name) values (163, 'Luminotecnia');
insert into Subjects (subject_id, subject_name) values (164, 'Control de la iluminación');
insert into Subjects (subject_id, subject_name) values (165, 'Proyectos fotográficos');
insert into Subjects (subject_id, subject_name) values (166, 'Toma fotográfica');
insert into Subjects (subject_id, subject_name) values (167, 'Tratamiento fotográfico digital');
insert into Subjects (subject_id, subject_name) values (168, 'Procesos finales fotográficos');
insert into Subjects (subject_id, subject_name) values (169, 'Grabación y edición de reportajes audiovisuales');
insert into Subjects (subject_id, subject_name) values (170, 'Proyecto de iluminación, captación y tratamiento de imagen');
-- INFORMÁTICA Y COMUNICACIONES
-- Administración de Sistemas Informáticos en Red y Distancia
insert into Subjects (subject_id, subject_name) values (171, 'Lenguajes de marcas y sistemas de gestión de información');
insert into Subjects (subject_id, subject_name) values (172, 'Implantación de sistemas operativos');
insert into Subjects (subject_id, subject_name) values (173, 'Planificación y administración de redes');
insert into Subjects (subject_id, subject_name) values (174, 'Fundamentos de hardware');
insert into Subjects (subject_id, subject_name) values (175, 'Gestión de bases de datos');
insert into Subjects (subject_id, subject_name) values (176, 'Administración de sistemas operativos');
insert into Subjects (subject_id, subject_name) values (177, 'Servicios de red e Internet');
insert into Subjects (subject_id, subject_name) values (178, 'Implantación de aplicaciones web');
insert into Subjects (subject_id, subject_name) values (179, 'Administración de sistemas gestores de bases de datos');
insert into Subjects (subject_id, subject_name) values (180, 'Seguridad y alta disponibilidad');
insert into Subjects (subject_id, subject_name) values (181, 'Proyecto de administración de sistemas informáticos en red');
-- Desarrollo de Aplicaciones Multiplataforma y Distancia
insert into Subjects (subject_id, subject_name) values (182, 'Sistemas informáticos');
insert into Subjects (subject_id, subject_name) values (183, 'Bases de Datos');
insert into Subjects (subject_id, subject_name) values (184, 'Programación');
insert into Subjects (subject_id, subject_name) values (185, 'Entornos de desarrollo');
insert into Subjects (subject_id, subject_name) values (186, 'Sistemas de gestión empresarial');
--  Desarrollo de Aplicaciones Web y Distancia tambien
insert into Subjects (subject_id, subject_name) values (187, 'Desarrollo de interfaces');
insert into Subjects (subject_id, subject_name) values (188, 'Programación multimedia y dispositivos móviles');
insert into Subjects (subject_id, subject_name) values (189, 'Programación de servicios y procesos');
insert into Subjects (subject_id, subject_name) values (190, 'Acceso a datos');
insert into Subjects (subject_id, subject_name) values (191, 'Proyecto de desarrollo de aplicaciones multiplataforma');
--  Desarrollo de Aplicaciones Web y Distancia
insert into Subjects (subject_id, subject_name) values (192, 'Desarrollo web en entorno cliente');
insert into Subjects (subject_id, subject_name) values (193, 'Desarrollo web en entorno servidor');
insert into Subjects (subject_id, subject_name) values (194, 'Despliegue de aplicaciones web');
insert into Subjects (subject_id, subject_name) values (195, 'Diseño de interfaces WEB');
insert into Subjects (subject_id, subject_name) values (196, 'Proyecto de desarrollo de aplicaciones web');
GO

-- Insert values to CourseSubjects
-- Ingles
insert into CourseSubjects (course_id, subject_id) values (1, 8);
insert into CourseSubjects (course_id, subject_id) values (2, 8);
insert into CourseSubjects (course_id, subject_id) values (3, 8);
insert into CourseSubjects (course_id, subject_id) values (4, 8);
insert into CourseSubjects (course_id, subject_id) values (5, 8);
insert into CourseSubjects (course_id, subject_id) values (6, 8);
insert into CourseSubjects (course_id, subject_id) values (7, 8);
insert into CourseSubjects (course_id, subject_id) values (8, 8);
insert into CourseSubjects (course_id, subject_id) values (9, 8);
insert into CourseSubjects (course_id, subject_id) values (10, 8);
insert into CourseSubjects (course_id, subject_id) values (11, 8);
insert into CourseSubjects (course_id, subject_id) values (12, 8);
insert into CourseSubjects (course_id, subject_id) values (13, 8);
insert into CourseSubjects (course_id, subject_id) values (14, 8);
insert into CourseSubjects (course_id, subject_id) values (15, 8);
insert into CourseSubjects (course_id, subject_id) values (16, 8);
insert into CourseSubjects (course_id, subject_id) values (17, 8);
insert into CourseSubjects (course_id, subject_id) values (18, 8);
insert into CourseSubjects (course_id, subject_id) values (19, 8);
insert into CourseSubjects (course_id, subject_id) values (20, 8);
insert into CourseSubjects (course_id, subject_id) values (21, 8);
insert into CourseSubjects (course_id, subject_id) values (22, 8);
insert into CourseSubjects (course_id, subject_id) values (23, 8);
insert into CourseSubjects (course_id, subject_id) values (24, 8);
insert into CourseSubjects (course_id, subject_id) values (25, 8);
insert into CourseSubjects (course_id, subject_id) values (26, 8);
insert into CourseSubjects (course_id, subject_id) values (27, 8);
insert into CourseSubjects (course_id, subject_id) values (28, 8);
insert into CourseSubjects (course_id, subject_id) values (29, 8);
insert into CourseSubjects (course_id, subject_id) values (30, 8);
insert into CourseSubjects (course_id, subject_id) values (31, 8);
insert into CourseSubjects (course_id, subject_id) values (32, 8);
-- Fol
insert into CourseSubjects (course_id, subject_id) values (1, 11);
insert into CourseSubjects (course_id, subject_id) values (2, 11);
insert into CourseSubjects (course_id, subject_id) values (3, 11);
insert into CourseSubjects (course_id, subject_id) values (4, 11);
insert into CourseSubjects (course_id, subject_id) values (5, 11);
insert into CourseSubjects (course_id, subject_id) values (6, 11);
insert into CourseSubjects (course_id, subject_id) values (7, 11);
insert into CourseSubjects (course_id, subject_id) values (8, 11);
insert into CourseSubjects (course_id, subject_id) values (9, 11);
insert into CourseSubjects (course_id, subject_id) values (10, 11);
insert into CourseSubjects (course_id, subject_id) values (11, 11);
insert into CourseSubjects (course_id, subject_id) values (12, 11);
insert into CourseSubjects (course_id, subject_id) values (13, 11);
insert into CourseSubjects (course_id, subject_id) values (14, 11);
insert into CourseSubjects (course_id, subject_id) values (15, 11);
insert into CourseSubjects (course_id, subject_id) values (16, 11);
insert into CourseSubjects (course_id, subject_id) values (17, 11);
insert into CourseSubjects (course_id, subject_id) values (18, 11);
insert into CourseSubjects (course_id, subject_id) values (19, 11);
insert into CourseSubjects (course_id, subject_id) values (20, 11);
insert into CourseSubjects (course_id, subject_id) values (21, 11);
insert into CourseSubjects (course_id, subject_id) values (22, 11);
insert into CourseSubjects (course_id, subject_id) values (23, 11);
insert into CourseSubjects (course_id, subject_id) values (24, 11);
insert into CourseSubjects (course_id, subject_id) values (25, 11);
insert into CourseSubjects (course_id, subject_id) values (26, 11);
insert into CourseSubjects (course_id, subject_id) values (27, 11);
insert into CourseSubjects (course_id, subject_id) values (28, 11);
insert into CourseSubjects (course_id, subject_id) values (29, 11);
insert into CourseSubjects (course_id, subject_id) values (30, 11);
insert into CourseSubjects (course_id, subject_id) values (31, 11);
insert into CourseSubjects (course_id, subject_id) values (32, 11);
-- Formacion en centro de trabajo
insert into CourseSubjects (course_id, subject_id) values (1, 12);
insert into CourseSubjects (course_id, subject_id) values (2, 12);
insert into CourseSubjects (course_id, subject_id) values (3, 12);
insert into CourseSubjects (course_id, subject_id) values (4, 12);
insert into CourseSubjects (course_id, subject_id) values (5, 12);
insert into CourseSubjects (course_id, subject_id) values (6, 12);
insert into CourseSubjects (course_id, subject_id) values (7, 12);
insert into CourseSubjects (course_id, subject_id) values (8, 12);
insert into CourseSubjects (course_id, subject_id) values (9, 12);
insert into CourseSubjects (course_id, subject_id) values (10, 12);
insert into CourseSubjects (course_id, subject_id) values (11, 12);
insert into CourseSubjects (course_id, subject_id) values (12, 12);
insert into CourseSubjects (course_id, subject_id) values (13, 12);
insert into CourseSubjects (course_id, subject_id) values (14, 12);
insert into CourseSubjects (course_id, subject_id) values (15, 12);
insert into CourseSubjects (course_id, subject_id) values (16, 12);
insert into CourseSubjects (course_id, subject_id) values (17, 12);
insert into CourseSubjects (course_id, subject_id) values (18, 12);
insert into CourseSubjects (course_id, subject_id) values (19, 12);
insert into CourseSubjects (course_id, subject_id) values (20, 12);
insert into CourseSubjects (course_id, subject_id) values (21, 12);
insert into CourseSubjects (course_id, subject_id) values (22, 12);
insert into CourseSubjects (course_id, subject_id) values (23, 12);
insert into CourseSubjects (course_id, subject_id) values (24, 12);
insert into CourseSubjects (course_id, subject_id) values (25, 12);
insert into CourseSubjects (course_id, subject_id) values (26, 12);
insert into CourseSubjects (course_id, subject_id) values (27, 12);
insert into CourseSubjects (course_id, subject_id) values (28, 12);
insert into CourseSubjects (course_id, subject_id) values (29, 12);
insert into CourseSubjects (course_id, subject_id) values (30, 12);
insert into CourseSubjects (course_id, subject_id) values (31, 12);
insert into CourseSubjects (course_id, subject_id) values (32, 12);
-- Gesti�n Administrativa y a distancia
insert into CourseSubjects (course_id, subject_id) values (1, 1);
insert into CourseSubjects (course_id, subject_id) values (2, 1);
insert into CourseSubjects (course_id, subject_id) values (1, 2);
insert into CourseSubjects (course_id, subject_id) values (2, 2);
insert into CourseSubjects (course_id, subject_id) values (1, 3);
insert into CourseSubjects (course_id, subject_id) values (2, 3);
insert into CourseSubjects (course_id, subject_id) values (1, 4);
insert into CourseSubjects (course_id, subject_id) values (2, 4);
insert into CourseSubjects (course_id, subject_id) values (1, 5);
insert into CourseSubjects (course_id, subject_id) values (2, 5);
insert into CourseSubjects (course_id, subject_id) values (1, 6);
insert into CourseSubjects (course_id, subject_id) values (2, 6);
insert into CourseSubjects (course_id, subject_id) values (1, 7);
insert into CourseSubjects (course_id, subject_id) values (2, 7);
insert into CourseSubjects (course_id, subject_id) values (1, 9);
insert into CourseSubjects (course_id, subject_id) values (2, 9);
insert into CourseSubjects (course_id, subject_id) values (1, 10);
insert into CourseSubjects (course_id, subject_id) values (2, 10);
-- Actividades Comerciales
insert into CourseSubjects (course_id, subject_id) values (7, 13);
insert into CourseSubjects (course_id, subject_id) values (7, 14);
insert into CourseSubjects (course_id, subject_id) values (7, 15);
insert into CourseSubjects (course_id, subject_id) values (7, 16);
insert into CourseSubjects (course_id, subject_id) values (7, 17);
insert into CourseSubjects (course_id, subject_id) values (7, 18);
insert into CourseSubjects (course_id, subject_id) values (7, 19);
insert into CourseSubjects (course_id, subject_id) values (7, 20);
insert into CourseSubjects (course_id, subject_id) values (7, 21);
insert into CourseSubjects (course_id, subject_id) values (7, 22);
-- Instalaciones Eléctricas y Automáticas
insert into CourseSubjects (course_id, subject_id) values (14, 23);
insert into CourseSubjects (course_id, subject_id) values (14, 24);
insert into CourseSubjects (course_id, subject_id) values (14, 25);
insert into CourseSubjects (course_id, subject_id) values (14, 26);
insert into CourseSubjects (course_id, subject_id) values (14, 27);
insert into CourseSubjects (course_id, subject_id) values (14, 28);
insert into CourseSubjects (course_id, subject_id) values (14, 29);
insert into CourseSubjects (course_id, subject_id) values (14, 30);
insert into CourseSubjects (course_id, subject_id) values (14, 31);
-- Instalaciones de TeleComunicaciones
insert into CourseSubjects (course_id, subject_id) values (13, 30);
insert into CourseSubjects (course_id, subject_id) values (13, 29);
insert into CourseSubjects (course_id, subject_id) values (13, 28);
insert into CourseSubjects (course_id, subject_id) values (13, 32);
insert into CourseSubjects (course_id, subject_id) values (13, 33);
insert into CourseSubjects (course_id, subject_id) values (13, 34);
insert into CourseSubjects (course_id, subject_id) values (13, 35);
insert into CourseSubjects (course_id, subject_id) values (13, 36);
insert into CourseSubjects (course_id, subject_id) values (13, 37);
-- Video Disc-Jockey y Sonido
insert into CourseSubjects (course_id, subject_id) values (20, 38);
insert into CourseSubjects (course_id, subject_id) values (20, 39);
insert into CourseSubjects (course_id, subject_id) values (20, 40);
insert into CourseSubjects (course_id, subject_id) values (20, 41);
insert into CourseSubjects (course_id, subject_id) values (20, 42);
insert into CourseSubjects (course_id, subject_id) values (20, 43);
insert into CourseSubjects (course_id, subject_id) values (20, 44);
-- Sistemas Microinformáticos y Redes y Distancia
insert into CourseSubjects (course_id, subject_id) values (25, 45);
insert into CourseSubjects (course_id, subject_id) values (26, 45);
insert into CourseSubjects (course_id, subject_id) values (25, 46);
insert into CourseSubjects (course_id, subject_id) values (26, 46);
insert into CourseSubjects (course_id, subject_id) values (25, 47);
insert into CourseSubjects (course_id, subject_id) values (26, 47);
insert into CourseSubjects (course_id, subject_id) values (25, 48);
insert into CourseSubjects (course_id, subject_id) values (26, 48);
insert into CourseSubjects (course_id, subject_id) values (25, 49);
insert into CourseSubjects (course_id, subject_id) values (26, 49);
insert into CourseSubjects (course_id, subject_id) values (25, 50);
insert into CourseSubjects (course_id, subject_id) values (26, 50);
insert into CourseSubjects (course_id, subject_id) values (25, 51);
insert into CourseSubjects (course_id, subject_id) values (26, 51);
insert into CourseSubjects (course_id, subject_id) values (25, 52);
insert into CourseSubjects (course_id, subject_id) values (26, 52);
-- Grado superior
-- Administración y Finanzas y Distancia
insert into CourseSubjects (course_id, subject_id) values (3, 53);
insert into CourseSubjects (course_id, subject_id) values (4, 53);
insert into CourseSubjects (course_id, subject_id) values (3, 54);
insert into CourseSubjects (course_id, subject_id) values (4, 54);
insert into CourseSubjects (course_id, subject_id) values (3, 55);
insert into CourseSubjects (course_id, subject_id) values (4, 55);
insert into CourseSubjects (course_id, subject_id) values (3, 56);
insert into CourseSubjects (course_id, subject_id) values (4, 56);
insert into CourseSubjects (course_id, subject_id) values (3, 57);
insert into CourseSubjects (course_id, subject_id) values (4, 57);
insert into CourseSubjects (course_id, subject_id) values (3, 58);
insert into CourseSubjects (course_id, subject_id) values (4, 58);
insert into CourseSubjects (course_id, subject_id) values (3, 59);
insert into CourseSubjects (course_id, subject_id) values (4, 59);
insert into CourseSubjects (course_id, subject_id) values (3, 60);
insert into CourseSubjects (course_id, subject_id) values (4, 60);
insert into CourseSubjects (course_id, subject_id) values (3, 61);
insert into CourseSubjects (course_id, subject_id) values (4, 61);
insert into CourseSubjects (course_id, subject_id) values (3, 62);
insert into CourseSubjects (course_id, subject_id) values (4, 62);
insert into CourseSubjects (course_id, subject_id) values (3, 63);
insert into CourseSubjects (course_id, subject_id) values (4, 63);
-- Asistencia a la Dirección y Distancia
insert into CourseSubjects (course_id, subject_id) values (5, 57);
insert into CourseSubjects (course_id, subject_id) values (6, 57);
insert into CourseSubjects (course_id, subject_id) values (5, 64);
insert into CourseSubjects (course_id, subject_id) values (6, 64);
insert into CourseSubjects (course_id, subject_id) values (5, 65);
insert into CourseSubjects (course_id, subject_id) values (6, 65);
insert into CourseSubjects (course_id, subject_id) values (5, 66);
insert into CourseSubjects (course_id, subject_id) values (6, 66);
insert into CourseSubjects (course_id, subject_id) values (5, 67);
insert into CourseSubjects (course_id, subject_id) values (6, 67);
insert into CourseSubjects (course_id, subject_id) values (5, 68);
insert into CourseSubjects (course_id, subject_id) values (6, 68);
-- COMERCIO Y MARKETING
-- Comercio Internacional y Distancia
insert into CourseSubjects (course_id, subject_id) values (8, 69);
insert into CourseSubjects (course_id, subject_id) values (9, 69);
insert into CourseSubjects (course_id, subject_id) values (10, 69);
insert into CourseSubjects (course_id, subject_id) values (11, 69);
insert into CourseSubjects (course_id, subject_id) values (12, 69);
insert into CourseSubjects (course_id, subject_id) values (8, 70);
insert into CourseSubjects (course_id, subject_id) values (9, 70);
insert into CourseSubjects (course_id, subject_id) values (8, 71);
insert into CourseSubjects (course_id, subject_id) values (9, 71);
insert into CourseSubjects (course_id, subject_id) values (8, 72);
insert into CourseSubjects (course_id, subject_id) values (9, 72);
insert into CourseSubjects (course_id, subject_id) values (8, 73);
insert into CourseSubjects (course_id, subject_id) values (9, 73);
insert into CourseSubjects (course_id, subject_id) values (10, 73);
insert into CourseSubjects (course_id, subject_id) values (8, 74);
insert into CourseSubjects (course_id, subject_id) values (9, 74);
insert into CourseSubjects (course_id, subject_id) values (8, 75);
insert into CourseSubjects (course_id, subject_id) values (9, 75);
insert into CourseSubjects (course_id, subject_id) values (11, 75);
insert into CourseSubjects (course_id, subject_id) values (10, 75);
insert into CourseSubjects (course_id, subject_id) values (8, 76);
insert into CourseSubjects (course_id, subject_id) values (9, 76);
insert into CourseSubjects (course_id, subject_id) values (10, 76);
insert into CourseSubjects (course_id, subject_id) values (8, 77);
insert into CourseSubjects (course_id, subject_id) values (9, 77);
insert into CourseSubjects (course_id, subject_id) values (8, 78);
insert into CourseSubjects (course_id, subject_id) values (9, 78);
insert into CourseSubjects (course_id, subject_id) values (8, 79);
insert into CourseSubjects (course_id, subject_id) values (9, 79);
-- Gestión de Ventas y Espacios Comerciales
insert into CourseSubjects (course_id, subject_id) values (11, 80);
insert into CourseSubjects (course_id, subject_id) values (11, 81);
insert into CourseSubjects (course_id, subject_id) values (11, 82);
insert into CourseSubjects (course_id, subject_id) values (11, 83);
insert into CourseSubjects (course_id, subject_id) values (11, 84);
insert into CourseSubjects (course_id, subject_id) values (12, 84);
insert into CourseSubjects (course_id, subject_id) values (11, 85);
insert into CourseSubjects (course_id, subject_id) values (11, 86);
insert into CourseSubjects (course_id, subject_id) values (12, 86);
insert into CourseSubjects (course_id, subject_id) values (11, 87);
insert into CourseSubjects (course_id, subject_id) values (10, 87);
insert into CourseSubjects (course_id, subject_id) values (11, 88);
-- Marketing y Publicidad
insert into CourseSubjects (course_id, subject_id) values (12, 89);
insert into CourseSubjects (course_id, subject_id) values (12, 90);
insert into CourseSubjects (course_id, subject_id) values (12, 91);
insert into CourseSubjects (course_id, subject_id) values (12, 92);
insert into CourseSubjects (course_id, subject_id) values (12, 93);
insert into CourseSubjects (course_id, subject_id) values (12, 94);
insert into CourseSubjects (course_id, subject_id) values (12, 95);
insert into CourseSubjects (course_id, subject_id) values (12, 96);
-- Transporte y Logística
insert into CourseSubjects (course_id, subject_id) values (10, 97);
insert into CourseSubjects (course_id, subject_id) values (10, 98);
insert into CourseSubjects (course_id, subject_id) values (10, 99);
insert into CourseSubjects (course_id, subject_id) values (10, 100);
insert into CourseSubjects (course_id, subject_id) values (10, 101);
-- Electricidad y electronica
-- Mantenimiento Electrónico
insert into CourseSubjects (course_id, subject_id) values (15, 102);
insert into CourseSubjects (course_id, subject_id) values (15, 103);
insert into CourseSubjects (course_id, subject_id) values (15, 104);
insert into CourseSubjects (course_id, subject_id) values (15, 105);
insert into CourseSubjects (course_id, subject_id) values (15, 106);
insert into CourseSubjects (course_id, subject_id) values (15, 107);
insert into CourseSubjects (course_id, subject_id) values (15, 108);
insert into CourseSubjects (course_id, subject_id) values (15, 109);
insert into CourseSubjects (course_id, subject_id) values (15, 110);
insert into CourseSubjects (course_id, subject_id) values (15, 111);
-- Sistemas de Telecomunicaciones e Informáticos y Distancia
insert into CourseSubjects (course_id, subject_id) values (16, 112);
insert into CourseSubjects (course_id, subject_id) values (17, 112);
insert into CourseSubjects (course_id, subject_id) values (16, 113);
insert into CourseSubjects (course_id, subject_id) values (17, 113);
insert into CourseSubjects (course_id, subject_id) values (16, 114);
insert into CourseSubjects (course_id, subject_id) values (17, 114);
insert into CourseSubjects (course_id, subject_id) values (16, 115);
insert into CourseSubjects (course_id, subject_id) values (17, 115);
insert into CourseSubjects (course_id, subject_id) values (16, 116);
insert into CourseSubjects (course_id, subject_id) values (17, 116);
insert into CourseSubjects (course_id, subject_id) values (16, 117);
insert into CourseSubjects (course_id, subject_id) values (17, 117);
insert into CourseSubjects (course_id, subject_id) values (16, 118);
insert into CourseSubjects (course_id, subject_id) values (17, 118);
insert into CourseSubjects (course_id, subject_id) values (16, 119);
insert into CourseSubjects (course_id, subject_id) values (17, 119);
insert into CourseSubjects (course_id, subject_id) values (16, 120);
insert into CourseSubjects (course_id, subject_id) values (17, 120);
insert into CourseSubjects (course_id, subject_id) values (16, 121);
insert into CourseSubjects (course_id, subject_id) values (17, 121);
insert into CourseSubjects (course_id, subject_id) values (16, 122);
insert into CourseSubjects (course_id, subject_id) values (17, 122);
-- Sistemas Electrotécnicos y Automatizados y Distancia
insert into CourseSubjects (course_id, subject_id) values (18, 123);
insert into CourseSubjects (course_id, subject_id) values (19, 123);
insert into CourseSubjects (course_id, subject_id) values (18, 124);
insert into CourseSubjects (course_id, subject_id) values (19, 124);
insert into CourseSubjects (course_id, subject_id) values (18, 125);
insert into CourseSubjects (course_id, subject_id) values (19, 125);
insert into CourseSubjects (course_id, subject_id) values (18, 126);
insert into CourseSubjects (course_id, subject_id) values (19, 126);
insert into CourseSubjects (course_id, subject_id) values (18, 127);
insert into CourseSubjects (course_id, subject_id) values (19, 127);
insert into CourseSubjects (course_id, subject_id) values (18, 128);
insert into CourseSubjects (course_id, subject_id) values (19, 128);
insert into CourseSubjects (course_id, subject_id) values (18, 129);
insert into CourseSubjects (course_id, subject_id) values (19, 129);
insert into CourseSubjects (course_id, subject_id) values (18, 130);
insert into CourseSubjects (course_id, subject_id) values (19, 130);
insert into CourseSubjects (course_id, subject_id) values (18, 131);
insert into CourseSubjects (course_id, subject_id) values (19, 131);
insert into CourseSubjects (course_id, subject_id) values (18, 132);
insert into CourseSubjects (course_id, subject_id) values (19, 132);
-- Imagen y sonido
-- Producción de Audiovisuales y Espectáculos
insert into CourseSubjects (course_id, subject_id) values (21, 133);
insert into CourseSubjects (course_id, subject_id) values (21, 134);
insert into CourseSubjects (course_id, subject_id) values (21, 135);
insert into CourseSubjects (course_id, subject_id) values (21, 136);
insert into CourseSubjects (course_id, subject_id) values (21, 137);
insert into CourseSubjects (course_id, subject_id) values (21, 138);
insert into CourseSubjects (course_id, subject_id) values (21, 139);
insert into CourseSubjects (course_id, subject_id) values (21, 140);
insert into CourseSubjects (course_id, subject_id) values (21, 141);
-- Realización de Proyectos Audiovisuales y Espectáculos
insert into CourseSubjects (course_id, subject_id) values (22, 142);
insert into CourseSubjects (course_id, subject_id) values (22, 143);
insert into CourseSubjects (course_id, subject_id) values (22, 144);
insert into CourseSubjects (course_id, subject_id) values (22, 145);
insert into CourseSubjects (course_id, subject_id) values (22, 146);
insert into CourseSubjects (course_id, subject_id) values (22, 147);
insert into CourseSubjects (course_id, subject_id) values (23, 147);
insert into CourseSubjects (course_id, subject_id) values (22, 148);
insert into CourseSubjects (course_id, subject_id) values (22, 149);
insert into CourseSubjects (course_id, subject_id) values (22, 150);
insert into CourseSubjects (course_id, subject_id) values (22, 151);
-- Animaciones 3D, Juegos y Entornos Interactivos
insert into CourseSubjects (course_id, subject_id) values (23, 153);
insert into CourseSubjects (course_id, subject_id) values (23, 154);
insert into CourseSubjects (course_id, subject_id) values (23, 155);
insert into CourseSubjects (course_id, subject_id) values (23, 156);
insert into CourseSubjects (course_id, subject_id) values (23, 157);
insert into CourseSubjects (course_id, subject_id) values (23, 158);
insert into CourseSubjects (course_id, subject_id) values (23, 159);
-- Iluminación, Captación y Tratamiento de Imagen
insert into CourseSubjects (course_id, subject_id) values (23, 160);
insert into CourseSubjects (course_id, subject_id) values (23, 161);
insert into CourseSubjects (course_id, subject_id) values (23, 162);
insert into CourseSubjects (course_id, subject_id) values (23, 163);
insert into CourseSubjects (course_id, subject_id) values (23, 164);
insert into CourseSubjects (course_id, subject_id) values (23, 165);
insert into CourseSubjects (course_id, subject_id) values (23, 166);
insert into CourseSubjects (course_id, subject_id) values (23, 167);
insert into CourseSubjects (course_id, subject_id) values (23, 168);
insert into CourseSubjects (course_id, subject_id) values (23, 169);
insert into CourseSubjects (course_id, subject_id) values (23, 170);
-- INFORMÁTICA Y COMUNICACIONES
-- Administración de Sistemas Informáticos en Red y Distancia
insert into CourseSubjects (course_id, subject_id) values (27, 171);
insert into CourseSubjects (course_id, subject_id) values (28, 171);
insert into CourseSubjects (course_id, subject_id) values (29, 171);
insert into CourseSubjects (course_id, subject_id) values (30, 171);
insert into CourseSubjects (course_id, subject_id) values (31, 171);
insert into CourseSubjects (course_id, subject_id) values (32, 171);
insert into CourseSubjects (course_id, subject_id) values (27, 172);
insert into CourseSubjects (course_id, subject_id) values (28, 172);
insert into CourseSubjects (course_id, subject_id) values (27, 173);
insert into CourseSubjects (course_id, subject_id) values (28, 173);
insert into CourseSubjects (course_id, subject_id) values (27, 174);
insert into CourseSubjects (course_id, subject_id) values (28, 174);
insert into CourseSubjects (course_id, subject_id) values (27, 175);
insert into CourseSubjects (course_id, subject_id) values (28, 175);
insert into CourseSubjects (course_id, subject_id) values (27, 176);
insert into CourseSubjects (course_id, subject_id) values (28, 176);
insert into CourseSubjects (course_id, subject_id) values (27, 177);
insert into CourseSubjects (course_id, subject_id) values (28, 177);
insert into CourseSubjects (course_id, subject_id) values (27, 178);
insert into CourseSubjects (course_id, subject_id) values (28, 178);
insert into CourseSubjects (course_id, subject_id) values (27, 179);
insert into CourseSubjects (course_id, subject_id) values (28, 179);
insert into CourseSubjects (course_id, subject_id) values (27, 180);
insert into CourseSubjects (course_id, subject_id) values (28, 180);
insert into CourseSubjects (course_id, subject_id) values (27, 181);
insert into CourseSubjects (course_id, subject_id) values (28, 181);
-- Desarrollo de Aplicaciones Multiplataforma y Distancia
insert into CourseSubjects (course_id, subject_id) values (29, 182);
insert into CourseSubjects (course_id, subject_id) values (30, 182);
insert into CourseSubjects (course_id, subject_id) values (31, 182);
insert into CourseSubjects (course_id, subject_id) values (32, 182);
insert into CourseSubjects (course_id, subject_id) values (29, 183);
insert into CourseSubjects (course_id, subject_id) values (30, 183);
insert into CourseSubjects (course_id, subject_id) values (31, 183);
insert into CourseSubjects (course_id, subject_id) values (32, 183);
insert into CourseSubjects (course_id, subject_id) values (29, 184);
insert into CourseSubjects (course_id, subject_id) values (30, 184);
insert into CourseSubjects (course_id, subject_id) values (31, 184);
insert into CourseSubjects (course_id, subject_id) values (32, 184);
insert into CourseSubjects (course_id, subject_id) values (29, 185);
insert into CourseSubjects (course_id, subject_id) values (30, 185);
insert into CourseSubjects (course_id, subject_id) values (31, 185);
insert into CourseSubjects (course_id, subject_id) values (32, 185);
insert into CourseSubjects (course_id, subject_id) values (29, 186);
insert into CourseSubjects (course_id, subject_id) values (30, 186);
insert into CourseSubjects (course_id, subject_id) values (31, 186);
insert into CourseSubjects (course_id, subject_id) values (32, 186);
insert into CourseSubjects (course_id, subject_id) values (29, 187);
insert into CourseSubjects (course_id, subject_id) values (30, 187);
insert into CourseSubjects (course_id, subject_id) values (29, 188);
insert into CourseSubjects (course_id, subject_id) values (30, 188);
insert into CourseSubjects (course_id, subject_id) values (29, 189);
insert into CourseSubjects (course_id, subject_id) values (30, 189);
insert into CourseSubjects (course_id, subject_id) values (29, 190);
insert into CourseSubjects (course_id, subject_id) values (30, 190);
insert into CourseSubjects (course_id, subject_id) values (29, 191);
insert into CourseSubjects (course_id, subject_id) values (30, 191);
--  Desarrollo de Aplicaciones Web y Distancia
insert into CourseSubjects (course_id, subject_id) values (31, 192);
insert into CourseSubjects (course_id, subject_id) values (32, 192);
insert into CourseSubjects (course_id, subject_id) values (31, 193);
insert into CourseSubjects (course_id, subject_id) values (32, 193);
insert into CourseSubjects (course_id, subject_id) values (31, 194);
insert into CourseSubjects (course_id, subject_id) values (32, 194);
insert into CourseSubjects (course_id, subject_id) values (31, 195);
insert into CourseSubjects (course_id, subject_id) values (32, 195);
insert into CourseSubjects (course_id, subject_id) values (31, 196);
insert into CourseSubjects (course_id, subject_id) values (32, 196);
go