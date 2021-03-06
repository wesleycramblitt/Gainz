PGDMP         5                w           Gainz    10.9    11.2 D    G           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                       false            H           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                       false            I           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                       false            J           1262    16393    Gainz    DATABASE     �   CREATE DATABASE "Gainz" WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'English_United States.1252' LC_CTYPE = 'English_United States.1252';
    DROP DATABASE "Gainz";
             postgres    false            �            1259    16445 
   DayMuscles    TABLE     v   CREATE TABLE public."DayMuscles" (
    "ID" integer NOT NULL,
    "DayID" integer NOT NULL,
    "MuscleID" integer
);
     DROP TABLE public."DayMuscles";
       public         postgres    false            �            1259    16443    DayMuscles_ID_seq    SEQUENCE     �   CREATE SEQUENCE public."DayMuscles_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 *   DROP SEQUENCE public."DayMuscles_ID_seq";
       public       postgres    false    206            K           0    0    DayMuscles_ID_seq    SEQUENCE OWNED BY     M   ALTER SEQUENCE public."DayMuscles_ID_seq" OWNED BY public."DayMuscles"."ID";
            public       postgres    false    205            �            1259    16401    Days    TABLE     j   CREATE TABLE public."Days" (
    "ID" integer NOT NULL,
    "Name" text,
    "IsRest" boolean NOT NULL
);
    DROP TABLE public."Days";
       public         postgres    false            �            1259    16399    Days_ID_seq    SEQUENCE     �   CREATE SEQUENCE public."Days_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 $   DROP SEQUENCE public."Days_ID_seq";
       public       postgres    false    198            L           0    0    Days_ID_seq    SEQUENCE OWNED BY     A   ALTER SEQUENCE public."Days_ID_seq" OWNED BY public."Days"."ID";
            public       postgres    false    197            �            1259    16463    ExerciseMuscles    TABLE     �   CREATE TABLE public."ExerciseMuscles" (
    "ExerciseMuscleID" integer NOT NULL,
    "MuscleID" integer NOT NULL,
    "percentInvolvement" integer NOT NULL,
    "ExerciseID" integer NOT NULL
);
 %   DROP TABLE public."ExerciseMuscles";
       public         postgres    false            �            1259    16461 $   ExerciseMuscles_ExerciseMuscleID_seq    SEQUENCE     �   CREATE SEQUENCE public."ExerciseMuscles_ExerciseMuscleID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 =   DROP SEQUENCE public."ExerciseMuscles_ExerciseMuscleID_seq";
       public       postgres    false    208            M           0    0 $   ExerciseMuscles_ExerciseMuscleID_seq    SEQUENCE OWNED BY     s   ALTER SEQUENCE public."ExerciseMuscles_ExerciseMuscleID_seq" OWNED BY public."ExerciseMuscles"."ExerciseMuscleID";
            public       postgres    false    207            �            1259    16412 	   Exercises    TABLE     �   CREATE TABLE public."Exercises" (
    "ExerciseID" integer NOT NULL,
    "Name" text,
    "ExerciseType" integer NOT NULL,
    "IsCompound" boolean NOT NULL
);
    DROP TABLE public."Exercises";
       public         postgres    false            �            1259    16410    Exercises_ExerciseID_seq    SEQUENCE     �   CREATE SEQUENCE public."Exercises_ExerciseID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 1   DROP SEQUENCE public."Exercises_ExerciseID_seq";
       public       postgres    false    200            N           0    0    Exercises_ExerciseID_seq    SEQUENCE OWNED BY     [   ALTER SEQUENCE public."Exercises_ExerciseID_seq" OWNED BY public."Exercises"."ExerciseID";
            public       postgres    false    199            �            1259    16423    Muscles    TABLE     k   CREATE TABLE public."Muscles" (
    "ID" integer NOT NULL,
    "Name" text,
    "Size" integer NOT NULL
);
    DROP TABLE public."Muscles";
       public         postgres    false            �            1259    16421    Muscles_ID_seq    SEQUENCE     �   CREATE SEQUENCE public."Muscles_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 '   DROP SEQUENCE public."Muscles_ID_seq";
       public       postgres    false    202            O           0    0    Muscles_ID_seq    SEQUENCE OWNED BY     G   ALTER SEQUENCE public."Muscles_ID_seq" OWNED BY public."Muscles"."ID";
            public       postgres    false    201            �            1259    16481 	   SplitDays    TABLE     }   CREATE TABLE public."SplitDays" (
    "ID" integer NOT NULL,
    "SplitID" integer NOT NULL,
    "DayID" integer NOT NULL
);
    DROP TABLE public."SplitDays";
       public         postgres    false            �            1259    16479    SplitDays_ID_seq    SEQUENCE     �   CREATE SEQUENCE public."SplitDays_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 )   DROP SEQUENCE public."SplitDays_ID_seq";
       public       postgres    false    210            P           0    0    SplitDays_ID_seq    SEQUENCE OWNED BY     K   ALTER SEQUENCE public."SplitDays_ID_seq" OWNED BY public."SplitDays"."ID";
            public       postgres    false    209            �            1259    16434    Splits    TABLE     �   CREATE TABLE public."Splits" (
    "ID" integer NOT NULL,
    "Name" text,
    "Description" text,
    "Frequency" integer NOT NULL
);
    DROP TABLE public."Splits";
       public         postgres    false            �            1259    16432    Splits_ID_seq    SEQUENCE     �   CREATE SEQUENCE public."Splits_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 &   DROP SEQUENCE public."Splits_ID_seq";
       public       postgres    false    204            Q           0    0    Splits_ID_seq    SEQUENCE OWNED BY     E   ALTER SEQUENCE public."Splits_ID_seq" OWNED BY public."Splits"."ID";
            public       postgres    false    203            �            1259    16394    __EFMigrationsHistory    TABLE     �   CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);
 +   DROP TABLE public."__EFMigrationsHistory";
       public         postgres    false            �
           2604    16448    DayMuscles ID    DEFAULT     t   ALTER TABLE ONLY public."DayMuscles" ALTER COLUMN "ID" SET DEFAULT nextval('public."DayMuscles_ID_seq"'::regclass);
 @   ALTER TABLE public."DayMuscles" ALTER COLUMN "ID" DROP DEFAULT;
       public       postgres    false    205    206    206            �
           2604    16404    Days ID    DEFAULT     h   ALTER TABLE ONLY public."Days" ALTER COLUMN "ID" SET DEFAULT nextval('public."Days_ID_seq"'::regclass);
 :   ALTER TABLE public."Days" ALTER COLUMN "ID" DROP DEFAULT;
       public       postgres    false    198    197    198            �
           2604    16466     ExerciseMuscles ExerciseMuscleID    DEFAULT     �   ALTER TABLE ONLY public."ExerciseMuscles" ALTER COLUMN "ExerciseMuscleID" SET DEFAULT nextval('public."ExerciseMuscles_ExerciseMuscleID_seq"'::regclass);
 S   ALTER TABLE public."ExerciseMuscles" ALTER COLUMN "ExerciseMuscleID" DROP DEFAULT;
       public       postgres    false    208    207    208            �
           2604    16415    Exercises ExerciseID    DEFAULT     �   ALTER TABLE ONLY public."Exercises" ALTER COLUMN "ExerciseID" SET DEFAULT nextval('public."Exercises_ExerciseID_seq"'::regclass);
 G   ALTER TABLE public."Exercises" ALTER COLUMN "ExerciseID" DROP DEFAULT;
       public       postgres    false    200    199    200            �
           2604    16426 
   Muscles ID    DEFAULT     n   ALTER TABLE ONLY public."Muscles" ALTER COLUMN "ID" SET DEFAULT nextval('public."Muscles_ID_seq"'::regclass);
 =   ALTER TABLE public."Muscles" ALTER COLUMN "ID" DROP DEFAULT;
       public       postgres    false    201    202    202            �
           2604    16484    SplitDays ID    DEFAULT     r   ALTER TABLE ONLY public."SplitDays" ALTER COLUMN "ID" SET DEFAULT nextval('public."SplitDays_ID_seq"'::regclass);
 ?   ALTER TABLE public."SplitDays" ALTER COLUMN "ID" DROP DEFAULT;
       public       postgres    false    209    210    210            �
           2604    16437 	   Splits ID    DEFAULT     l   ALTER TABLE ONLY public."Splits" ALTER COLUMN "ID" SET DEFAULT nextval('public."Splits_ID_seq"'::regclass);
 <   ALTER TABLE public."Splits" ALTER COLUMN "ID" DROP DEFAULT;
       public       postgres    false    204    203    204            @          0    16445 
   DayMuscles 
   TABLE DATA               A   COPY public."DayMuscles" ("ID", "DayID", "MuscleID") FROM stdin;
    public       postgres    false    206   �L       8          0    16401    Days 
   TABLE DATA               8   COPY public."Days" ("ID", "Name", "IsRest") FROM stdin;
    public       postgres    false    198   �M       B          0    16463    ExerciseMuscles 
   TABLE DATA               o   COPY public."ExerciseMuscles" ("ExerciseMuscleID", "MuscleID", "percentInvolvement", "ExerciseID") FROM stdin;
    public       postgres    false    208   3N       :          0    16412 	   Exercises 
   TABLE DATA               Y   COPY public."Exercises" ("ExerciseID", "Name", "ExerciseType", "IsCompound") FROM stdin;
    public       postgres    false    200   �R       <          0    16423    Muscles 
   TABLE DATA               9   COPY public."Muscles" ("ID", "Name", "Size") FROM stdin;
    public       postgres    false    202   iV       D          0    16481 	   SplitDays 
   TABLE DATA               ?   COPY public."SplitDays" ("ID", "SplitID", "DayID") FROM stdin;
    public       postgres    false    210   dW       >          0    16434    Splits 
   TABLE DATA               L   COPY public."Splits" ("ID", "Name", "Description", "Frequency") FROM stdin;
    public       postgres    false    204   $X       6          0    16394    __EFMigrationsHistory 
   TABLE DATA               R   COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
    public       postgres    false    196   �X       R           0    0    DayMuscles_ID_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('public."DayMuscles_ID_seq"', 1, false);
            public       postgres    false    205            S           0    0    Days_ID_seq    SEQUENCE SET     <   SELECT pg_catalog.setval('public."Days_ID_seq"', 1, false);
            public       postgres    false    197            T           0    0 $   ExerciseMuscles_ExerciseMuscleID_seq    SEQUENCE SET     V   SELECT pg_catalog.setval('public."ExerciseMuscles_ExerciseMuscleID_seq"', 489, true);
            public       postgres    false    207            U           0    0    Exercises_ExerciseID_seq    SEQUENCE SET     I   SELECT pg_catalog.setval('public."Exercises_ExerciseID_seq"', 99, true);
            public       postgres    false    199            V           0    0    Muscles_ID_seq    SEQUENCE SET     ?   SELECT pg_catalog.setval('public."Muscles_ID_seq"', 1, false);
            public       postgres    false    201            W           0    0    SplitDays_ID_seq    SEQUENCE SET     A   SELECT pg_catalog.setval('public."SplitDays_ID_seq"', 1, false);
            public       postgres    false    209            X           0    0    Splits_ID_seq    SEQUENCE SET     >   SELECT pg_catalog.setval('public."Splits_ID_seq"', 1, false);
            public       postgres    false    203            �
           2606    16450    DayMuscles PK_DayMuscles 
   CONSTRAINT     \   ALTER TABLE ONLY public."DayMuscles"
    ADD CONSTRAINT "PK_DayMuscles" PRIMARY KEY ("ID");
 F   ALTER TABLE ONLY public."DayMuscles" DROP CONSTRAINT "PK_DayMuscles";
       public         postgres    false    206            �
           2606    16409    Days PK_Days 
   CONSTRAINT     P   ALTER TABLE ONLY public."Days"
    ADD CONSTRAINT "PK_Days" PRIMARY KEY ("ID");
 :   ALTER TABLE ONLY public."Days" DROP CONSTRAINT "PK_Days";
       public         postgres    false    198            �
           2606    16468 "   ExerciseMuscles PK_ExerciseMuscles 
   CONSTRAINT     t   ALTER TABLE ONLY public."ExerciseMuscles"
    ADD CONSTRAINT "PK_ExerciseMuscles" PRIMARY KEY ("ExerciseMuscleID");
 P   ALTER TABLE ONLY public."ExerciseMuscles" DROP CONSTRAINT "PK_ExerciseMuscles";
       public         postgres    false    208            �
           2606    16420    Exercises PK_Exercises 
   CONSTRAINT     b   ALTER TABLE ONLY public."Exercises"
    ADD CONSTRAINT "PK_Exercises" PRIMARY KEY ("ExerciseID");
 D   ALTER TABLE ONLY public."Exercises" DROP CONSTRAINT "PK_Exercises";
       public         postgres    false    200            �
           2606    16431    Muscles PK_Muscles 
   CONSTRAINT     V   ALTER TABLE ONLY public."Muscles"
    ADD CONSTRAINT "PK_Muscles" PRIMARY KEY ("ID");
 @   ALTER TABLE ONLY public."Muscles" DROP CONSTRAINT "PK_Muscles";
       public         postgres    false    202            �
           2606    16486    SplitDays PK_SplitDays 
   CONSTRAINT     Z   ALTER TABLE ONLY public."SplitDays"
    ADD CONSTRAINT "PK_SplitDays" PRIMARY KEY ("ID");
 D   ALTER TABLE ONLY public."SplitDays" DROP CONSTRAINT "PK_SplitDays";
       public         postgres    false    210            �
           2606    16442    Splits PK_Splits 
   CONSTRAINT     T   ALTER TABLE ONLY public."Splits"
    ADD CONSTRAINT "PK_Splits" PRIMARY KEY ("ID");
 >   ALTER TABLE ONLY public."Splits" DROP CONSTRAINT "PK_Splits";
       public         postgres    false    204            �
           2606    16398 .   __EFMigrationsHistory PK___EFMigrationsHistory 
   CONSTRAINT     {   ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");
 \   ALTER TABLE ONLY public."__EFMigrationsHistory" DROP CONSTRAINT "PK___EFMigrationsHistory";
       public         postgres    false    196            �
           1259    16497    IX_DayMuscles_DayID    INDEX     Q   CREATE INDEX "IX_DayMuscles_DayID" ON public."DayMuscles" USING btree ("DayID");
 )   DROP INDEX public."IX_DayMuscles_DayID";
       public         postgres    false    206            �
           1259    16498    IX_DayMuscles_MuscleID    INDEX     W   CREATE INDEX "IX_DayMuscles_MuscleID" ON public."DayMuscles" USING btree ("MuscleID");
 ,   DROP INDEX public."IX_DayMuscles_MuscleID";
       public         postgres    false    206            �
           1259    16499    IX_ExerciseMuscles_ExerciseID    INDEX     e   CREATE INDEX "IX_ExerciseMuscles_ExerciseID" ON public."ExerciseMuscles" USING btree ("ExerciseID");
 3   DROP INDEX public."IX_ExerciseMuscles_ExerciseID";
       public         postgres    false    208            �
           1259    16500    IX_ExerciseMuscles_MuscleID    INDEX     a   CREATE INDEX "IX_ExerciseMuscles_MuscleID" ON public."ExerciseMuscles" USING btree ("MuscleID");
 1   DROP INDEX public."IX_ExerciseMuscles_MuscleID";
       public         postgres    false    208            �
           1259    16501    IX_SplitDays_DayID    INDEX     O   CREATE INDEX "IX_SplitDays_DayID" ON public."SplitDays" USING btree ("DayID");
 (   DROP INDEX public."IX_SplitDays_DayID";
       public         postgres    false    210            �
           1259    16502    IX_SplitDays_SplitID    INDEX     S   CREATE INDEX "IX_SplitDays_SplitID" ON public."SplitDays" USING btree ("SplitID");
 *   DROP INDEX public."IX_SplitDays_SplitID";
       public         postgres    false    210            �
           2606    16451 #   DayMuscles FK_DayMuscles_Days_DayID    FK CONSTRAINT     �   ALTER TABLE ONLY public."DayMuscles"
    ADD CONSTRAINT "FK_DayMuscles_Days_DayID" FOREIGN KEY ("DayID") REFERENCES public."Days"("ID") ON DELETE CASCADE;
 Q   ALTER TABLE ONLY public."DayMuscles" DROP CONSTRAINT "FK_DayMuscles_Days_DayID";
       public       postgres    false    198    206    2724            �
           2606    16456 )   DayMuscles FK_DayMuscles_Muscles_MuscleID    FK CONSTRAINT     �   ALTER TABLE ONLY public."DayMuscles"
    ADD CONSTRAINT "FK_DayMuscles_Muscles_MuscleID" FOREIGN KEY ("MuscleID") REFERENCES public."Muscles"("ID") ON DELETE RESTRICT;
 W   ALTER TABLE ONLY public."DayMuscles" DROP CONSTRAINT "FK_DayMuscles_Muscles_MuscleID";
       public       postgres    false    202    2728    206            �
           2606    16469 7   ExerciseMuscles FK_ExerciseMuscles_Exercises_ExerciseID    FK CONSTRAINT     �   ALTER TABLE ONLY public."ExerciseMuscles"
    ADD CONSTRAINT "FK_ExerciseMuscles_Exercises_ExerciseID" FOREIGN KEY ("ExerciseID") REFERENCES public."Exercises"("ExerciseID") ON DELETE CASCADE;
 e   ALTER TABLE ONLY public."ExerciseMuscles" DROP CONSTRAINT "FK_ExerciseMuscles_Exercises_ExerciseID";
       public       postgres    false    200    208    2726            �
           2606    16474 3   ExerciseMuscles FK_ExerciseMuscles_Muscles_MuscleID    FK CONSTRAINT     �   ALTER TABLE ONLY public."ExerciseMuscles"
    ADD CONSTRAINT "FK_ExerciseMuscles_Muscles_MuscleID" FOREIGN KEY ("MuscleID") REFERENCES public."Muscles"("ID") ON DELETE CASCADE;
 a   ALTER TABLE ONLY public."ExerciseMuscles" DROP CONSTRAINT "FK_ExerciseMuscles_Muscles_MuscleID";
       public       postgres    false    2728    202    208            �
           2606    16487 !   SplitDays FK_SplitDays_Days_DayID    FK CONSTRAINT     �   ALTER TABLE ONLY public."SplitDays"
    ADD CONSTRAINT "FK_SplitDays_Days_DayID" FOREIGN KEY ("DayID") REFERENCES public."Days"("ID") ON DELETE CASCADE;
 O   ALTER TABLE ONLY public."SplitDays" DROP CONSTRAINT "FK_SplitDays_Days_DayID";
       public       postgres    false    2724    198    210            �
           2606    16492 %   SplitDays FK_SplitDays_Splits_SplitID    FK CONSTRAINT     �   ALTER TABLE ONLY public."SplitDays"
    ADD CONSTRAINT "FK_SplitDays_Splits_SplitID" FOREIGN KEY ("SplitID") REFERENCES public."Splits"("ID") ON DELETE CASCADE;
 S   ALTER TABLE ONLY public."SplitDays" DROP CONSTRAINT "FK_SplitDays_Splits_SplitID";
       public       postgres    false    210    2730    204            @   �   x�%��q@!�V1��?�����va������x/x~��G�g�"G,����H�!JD۵t���y�,/��F���)����׎�@�8�0jV��9Z^g�|eP!��+U+||W��W��I��Frp7�m���w����<s7���k��&4�HM���#:Hn�y.�;����ܽ������[i�5��w�#�kF<8�'qʑ�%M	ɣ��ú`��3��������wL�      8   r   x�3�J-.�,�2�t+��Qp�O��L�2�t� ��q�p:%&g���E��@��Oj:�a���_���Z�Yp:&�hK΀�� �� ����9C
R�@L#N��r03F��� ��!X      B   q  x�5�ɵ�0��`�i_r���1 U��ݰHB��_���_[�^�_гa}�>�hī���^����|�?��8!���Q��x�7X����[�h<�޿�~L8����7�� �UH��m��	����WH����lhEH>���כ��U^M޿��M|И�oL�U�w���!V=9�+�Q��)h��YcXA�~�zs�2�5_��ʷrM���5o��F���ƌ']^���_X^���ߘ]���ּx/�<�5Yqo�E#N�i�W�,NGo��`j	���WoAo�������y��_+�Wp�pę�9s0g����q�׼�f1���FW4��ܟ'�}SK0��s0kct1y�;y�N�3��&�s|2��2�g�3s{��6�y;�y8��,��o^�gʫI>��`�nʟIn��Z
f.�<Y��Z�h�â�`�X�A#O�.������?�3�Y�q��V]-Y��'o4�J��i����e$W��P{����9��ۓq��L�%oq��k�^��]��7����]�Y{�7/�1g\�|�y�;���{�&Wb�3�ﾎ�<�<�V�a���ͷ�嫳��MYs�#�o�8�54b�e�.br�U�'���5����N��	>h���k�>����
�4��<�ȇ��s|��s|7����*�i��9k�?#k1/4f��-|g�d�V�,Os�����Lջ��&��k'���={���
>�U��ԅOAoh����M^h���Q��7��1�[��$����0�����`�2x��n�7R�~�Wf��n���)%^�1L7�1w�13{��*��P��R��1cZYC��5dK���n"x�Ř9Ń��w�<*��g0y�,)n�Y2�,�}S9���1�3��F�D ���'�ޝ���|��ý�����a�}O&�T/]v�j���UgD����߅� ��8�Ԍ��ܽ��m�K��:u��7lOf'/N*s��/�`v�yj�_��Y�����>F��`���6��ɟ���qにEG�\-fo���ڱ�6�7<�����9�ś�Z�&|7�����rU��j	nh̝�)�|���ܓZ�;��9�����jUm�Z�az�Y���E	��g���o�|�E0�v0-��:���������4��      :   �  x��V=s�0��_���X�Ҙ�uһ�ꋓ�mӖ.��RR����DQ��n1� <B@B��v��i�e�;w��e�Z��">�g�Q�x^0�ʑ���J��%��$5WI܅.�>cU���3�eD"�]�_K�z�Ы�)�KH�M���ʊ,�wt!��0,�0s'���dܲ��d�vx�[�3oA��C}RT���du�:6D�<AE���R�ݾP�v~B���E�[4$�
eDŽ�����r�Ɇњ��T!	ъm��=�9ґ�8��9��k|�#�&���3�'�gkE���o�5��~�5�zd��zU�~4�K?�>�Q�b���5x~2�6E�w�h��V�רּ�5B��2?f5�����o��^)�z�^0ELRx�WLG�&r�Ш��!�#�=�J
C���6n���Ԥ`�-\��_���5@]k��0�=C|�*j�z�s�rS�W����{�O���zH��Xu�6��%χXj���82m�zq65+նRv�<��5�Q/�"�y��qԟj�"_|�[���E���^ q�EN��y~hˊB� IՌ!х�%Es�hLxS��#=�S%��d��E-М�c��k&Es��v��A���Y��B�k-�����^��vei{��5ϯa|����Ia�Z��z��U�Y7S�g�BAz:�@	Q�`�KZ�>����L(g�w���92/G�3���'^����LB8I���2߱�r����3��U�z�TBB��:<!�=|%��k��*�$S���K�a@���i��)��]<}\��0�}��㓫��"�K��˼�f8_�K
;�3�l���*�4%p&��O��Z�[\	t�y�9W_�A�3�{�3Z���������� �mW�F�Cۮ�J�D��RT�1�m*N���jZ]҄��w���ig�׷�l���G�      <   �   x�M��R�0�뻧P	c[r�$�$���%���H2�>�8���]�J9��vb�j�@�Am����k:�O���X����������ɃBYr���'�}�:�%���j<HT�8��R�!�}9�v�irה��!�(W�g|IlPA,���Gjұ�]}p]IZ���w��Xwg=���q��L�%��ֺ0�Ul��m�V��A7],�����L�e6ǹjrJ|�C�oI/n�      D   �   x�-�ۑ� �oT�~z��ױ6�Gr�<�!�t)�Y{k�x�|�����%��(d��V��M�C����ANᐯ��-t�W���.�
�P/�9���7�U�n���0gm�>$u7��m�'�Peo��{�'h����c�c��6[g�F�Mz��W�y�;�B�����t�?\      >   �   x�]�A�@��3�b~A4��tO:t)�R��5M�}�B�zx�}<�(J���G��p.�����Ԡ�4�J�H��8�7Ɛ����mS��EfN2��S����T^-d���6�-�=l�e�&`d���e���YA����k(B@����h���H/��m��?��n(      6   4   x�320�4032640611����,�L��4�3�3�-*��56203����� �}
l     