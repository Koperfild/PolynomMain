using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomNewVision
{
    //Делать проверку соответствия левых и правых скобок. Через стэк или ещё как
    
    class EntitiesArray:IComparable
    {
        public List<Entity> Massiv = new List<Entity>();
        public EntitiesArray(){}
        public EntitiesArray(List<Entity> S){
            this.Massiv=S;
        }
        public string ToString(){
            string s="";
            if (Massiv.Count!=0) s+=Massiv[0].ToString();//Это чтобы не печатать первый плюс
            for (int i=1;i<Massiv.Count;++i){
                if (Massiv[i].coef<0) s+=Massiv[i].ToString();
                else s+="+"+Massiv[i].ToString();
            }
            return s;
        }
        //CompareTo юзать потом в EntitiesArray.Sort()
        public int CompareTo(object Y){//Реализовывать. Надо чтобы красиво выводить в суммах сначала х1, потом х2 ну или х1 потом х1х2
             
        }
        public static EntitiesArray sum2EntitiesArrays(EntitiesArray EA1,EntitiesArray EA2)
        { 
            EA1.Massiv.AddRange(EA2.Massiv);
            return new EntitiesArray(EA1.Massiv);
            //Тут короче удаление лишних сущностей и слияние одинаковых в одну с новым коэффициентом
            //Можно упорядочить полином по индексам.См CompareTo
        }
        public void delSimilarTerms(){
            for (int i=0;i<Massiv.Count;i++){
                if 
            }
        }
        public EntitiesArray multiply2EntitiesArrays(EntitiesArray EA1,EntitiesArray EA2){
            List<Entity> L=new List<Entity>();
            for (int i=0;i<EA1.Massiv.Count;i++){
                for (int j=0;j<EA2.Massiv.Count;j++){
                    L.Add(Entity.multiply2Entities(EA1.Massiv[i],EA2.Massiv[j]));//Опять же что будет если будет L.Add(null)
                }
            }
             return new EntitiesArray(L);
        }
        public bool readSyshnost(string polynom,out bool )
        {
            //Тут короче читаем строку и откусываем первый член многочлена, укорачиваю строку полинома
            //если сущность (член полинома) без скобки справа, то false, инача true. 
            return true;
        }
        public EntitiesArray TreeWalk(PolynomTree P){
            EntitiesArray E=new EntitiesArray();
            EntitiesArray BranchArray = new EntitiesArray();
            if (P.child.Count!=0){
                for (int i=0;i<P.child.Count;++i){
                    BranchArray = TreeWalk(P.child[i]);
                    E.Massiv.AddRange(P.S.multiplyByEntitiesArray(BranchArray.Massiv).Massiv);
                }
            }
            else{
                //Тут короче ёбнули ДИМУ
                E.Massiv.Add(P.S);
                //return (P.parent.S.multiplyByEntitiesArray(E.Massiv));
                return E;
            }
            return E;
        }
    }
    class PolynomTree{
        public List<PolynomTree> child{get;set;}
        public PolynomTree parent{get;set;}
        public Entity S{get;set;}
        public static PolynomTree Root{get;set;}
        public static PolynomTree currentNode{get;set;}//А нужно ли? ДЛя текущего положения в
        public void addSyshnostNode(Entity S){
            PolynomTree P=new PolynomTree();
            this.child.Add(P);
            P.parent=this;
            P.S=this.S;
        }
        public EntitiesArray calcPolynom(string[] polynomParts){
            //Делать это вне и передавать уже массив строк parts
            //string[] parts=polynom.Split(new char[]{' '},StringSplitOptions.RemoveEmptyEntries);
            if (polynomParts.Length==0) return null;
        }
    }
    class CalculatePolinom
    {
        string polynom;

        public string calc(string polynom){
            if (!polynomEmpty())
            {
                EntitiesArray MassivSyshnostei = new EntitiesArray();
                MassivSyshnostei.readSyshnost()
            }

        }
        public bool polynomEmpty(){
            //Тут короче после чтения readSyshnost надо проверять оставшуюся строку polynom на отсутствие членов полинома. 
            //Т.е. могут остаться огрызки из скобок или ещё чего
            //Если остались только скобки разные return true;else return false;
        }
    } 
    public struct Elem:IComparable,IEqualityComparer<Elem>
    {
        public string varName{get;set;}
        public double power{get;set;}
        public int CompareTo(object Y){
            Elem E2=(Elem)Y;
            return this.varName.CompareTo(E2.varName);
        }
        public static bool EqualsByVarName(Elem X,Elem Y){//Equality by varName
            if (X.CompareTo((object)Y) == 0) return true;
            else return false;
        }
        public static bool EqualsByVarNameAndPower(Elem X,Elem Y){
            if (Elem.EqualsByVarName(X,Y) && X.power==Y.power) return true;
            else return false;
        }

        public override string ToString()
        {
            string s="";
            if (power==1) return s+=varName;
            else return s+=varName+"^"+power.ToString();
        }
    }
    public class Entity:IComparable
    {
        public double coef{get;set;}
        public List<Elem> element{get;set;}
        public Entity(List<string> elem)
        {
            for (int i=0;i<elem.Count;++i){
                Elem e;
                e.varName=elem[i];
                e.power=1;
                element.Add(e);
            }

            //Можно потом доделать, указав вначале единственный способ ввода (с * или без).Тут приведение к выбранному стандарту хранения и обработки сущностей
            distinct();
            //castToConventionalLook();
            //делать всё lowercase или uppercase в начальной строке полинома
        }
        public override string ToString()
        {
            string s="";
            s+=coef.ToString();
            if (element.Count!=0)
 	        for (int i=0;i<element.Count;++i){
                s+=element[i].ToString();
            }
            return s;
        }
        void castToConventionalLook()
        {
            //приведение к выбранному стандарту
        }
        public int CompareTo(Entity E){
            if (this.element.c
        }
        /// <summary>
        /// Orders alphabetically.
        /// Deletes copies. Merge identical variables in one summirazing its degree.
        /// Sort method relies on implementation of IComparable by Elem
        /// </summary>
        public void distinct(){
            element.Sort();//Проверить мой ли CompareTo вызывается
            for (int i=0;i<element.Count-1;++i){
                if (Elem.EqualsByVarName(element[i],element[i+1])){
                    Elem E;
                    E.power=element[i].power+element[i+1].power;//Потому что структура тип значение и нельзя менять значение http://hashcode.ru/questions/209501/c-%D0%B8%D1%81%D0%BF%D0%BE%D0%BB%D1%8C%D0%B7%D0%BE%D0%B2%D0%B0%D0%BD%D0%B8%D0%B5-%D0%BA%D0%BE%D0%BB%D0%BB%D0%B5%D0%BA%D1%86%D0%B8%D0%B8-%D1%81%D1%82%D1%80%D1%83%D0%BA%D1%82%D1%83%D1%80
                    E.varName=element[i].varName;
                    element[i]=E;
                    element.RemoveAt(i+1);
                    i--;
                }
            }
        }
        /// <summary>
        /// Equality by variables 
        /// </summary>
        /// <param name="S1"></param>
        /// <param name="S2"></param>
        /// <returns></returns>
        public static bool Equals(Entity S1, Entity S2)
        {
            if (S1.element.Count!=S2.element.Count) return false;
            else{
                for (int i=0;i<S1.element.Count;++i){
                    if (!Elem.EqualsByVarNameAndPower(S1.element[i],S2.element[i])) return false;
                }
                return true;
            }
        }
        public static EntitiesArray sum2Entities(Entity S1,Entity S2){
            List<Entity> L=new List<Entity>();
            if (Entity.Equals(S1,S2)){
                S1.coef=S1.coef+S2.coef;
                L.Add(S1);
            }
            //if (S1.coef==0) return null;
            else{
                L.Add(S1);
                L.Add(S2);
            }
            return new EntitiesArray(L);
        }
        //Узнавать что даёт List.Add(null) и как вообще обходится с нулевыми результатами
        public static Entity multiply2Entities(Entity S1,Entity S2){//null if coef = 0
            S1.coef=S1.coef*S2.coef;
            if (S1.coef!=0){
                S1.element.AddRange(S2.element);
                S1.distinct();
                return S1;
            }
            else return null;
        }
        /*public EntitiesArray multiplyByEntitiesArray(List<Entity> S){
            for (int i=0;i<S.Count;++i){
                S[i]=this.multiply2Entities(S[i]);
                if (S[i]==null){
                    S.RemoveAt(i);
                }
            }
            if (S.Count==0) return null;
            else{
                EntitiesArray E=new EntitiesArray(S);
                return E;
            }
        }*/
    }
    public class ExpressionBuilder{//обход дерева
        public string polynom{get;set;}
        int index=0;//current position in polynom string
        public ExpressionBuilder(string polynom){
            this.polynom=polynom;
        }
        public TreeNode build(){
            skip(" ");
            if (polynom[index]=='('){
                index++;
                build();
                skip(")");
            }
            Entity X1=readEntity();
            TreeNode L1=new TreeLeaf(X1);
            string op;
            while ((op=readOp())!=null){
                TreeNode X2=build();
                TreeNode leaf=new TreeNodeOp(X1,X2,op);
                return leaf;
            }
            return L1;

        }
        //Перенести в Entity
        public Entity readEntity(){
            skip(" ");
            int p0=index;
            while (Char.IsLetterOrDigit(polynom[index]) || /*polynom[index]=='.' ||*/ polynom[index]==','){//ДЕЛАТЬ В НАЧАЛЕ всех вычислений проход по полиному и замену точек на запятые!!!!!!!!!!!!!!!!!
                index++;
            }
            if (p0==index) throw new Exception("p9zdec nas9nika");
            //Тут можно делать проверку на минус перед числом. Хз как
            return parseEntity(p0);
        }
        //Перенести в Entity
        public Entity parseEntity(int p0){
            double coef;
            string temp="";
            while ((Char.IsDigit(polynom[p0]) || /*polynom[p0]=='.' ||*/ polynom[p0]==',') && p0 < index){
                //Делать в начале прохода проверку на двойные точки или запятые
                temp+=polynom[p0];
                p0++;
            }
            if (!double.TryParse(temp,out coef)) throw new Exception("fck coef");
            List<string> parameters=new List<string>();
            temp="";
            bool oneVar=false;
            while (p0 < index){
                
                if (Char.IsLetter(polynom[p0])){
                    temp+=polynom[p0];
                    p0++;
                    while(Char.IsDigit(polynom[p0]) && p0 < index){
                        temp+=polynom[p0];
                        p0++;
                    }
                    parameters.Add(temp);
                }
            }
            Entity E=new Entity(parameters);
            return E;
        }
        public string readOp(){
            skip(" ");
            for (int i=0;i<Operations.op.Length;++i){
                if (polynom.Substring(index).StartsWith(Operations.op[i])){
                    skip(Operations.op[i]);
                    return Operations.op[i];
                }
            }
            return null;
        }
        
        public void checkArguments(int p0){
            while() {}
        
            
            int p0=index;
            while(p0<polynom.Length){
                if (!Char.IsLetterOrDigit(polynom[p0])){
                    break;
                }
                index++;
            }
        }
        public void skip(string s){
            if (polynom.Substring(index).StartsWith(s)){
                index+=s.Length;
            }
        }
    }
    public struct Operations{
        public static string[] op=new string[]{"+","-","*","^"};
    }
    
    public abstract class TreeNode{
        public EntitiesArray EA{get;set;}
        abstract public EntitiesArray execute();
    }
    public class TreeNodeOp:TreeNode{
        public static TreeNodeOp Root;
        public string op;
        public TreeNode TrLeft,TrRight;
        public TreeNodeOp(TreeNode X1,TreeNode X2,string op){
            TrLeft=X1;
            TrRight=X2;
            this.op=op;
        }
        public EntitiesArray execute(){
            if (op=="+"){
                return EA=EntitiesArray.sum2Entities(TrLeft.E,TrRight.E));
            }
            else if (op=="-"){
                return EA=EntitiesArray.subtr2Entities(TrLeft.E,TrRight.E));//Написать метод subtr2Entities
            }
            else if (op=="*"){
                return EA=EntitiesArray.multiply2Entities(TrLeft.E,TrRight.E));
            }
            else if (op=="^"){
                return EA=EntitiesArray.pow(TrLeft.E,TrRight.E));//Написать метод pow
            }
            else{throw new Exception("ebat");}
        }
    }
    public class TreeLeaf:TreeNode{
        public TreeLeaf(Entity E){
            this.EA.Massiv.Add(E);
        }
        public EntitiesArray execute(){
            return EA;
        }
    }
    public class UnaryLeaf:TreeNode{
        
        public UnaryLeaf(Entity E){
            E.coef*=(-1);
            this.EA.Massiv.Add(E);
        }
        public EntitiesArray execute(){
            return EA;
        }
    }
}

