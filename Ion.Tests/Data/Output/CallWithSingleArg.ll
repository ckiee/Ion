; ModuleID = 'entry'
source_filename = "entry"

@str_0 = private unnamed_addr constant [12 x i8] c"Test string\00"

define void @Test(i8*) {
entry:
  ret void
}

define void @main() {
entry:
  %anonymous_12 = call void @Test(i8* getelementptr inbounds ([12 x i8], [12 x i8]* @str_0, i32 0, i32 0))
  ret void
}