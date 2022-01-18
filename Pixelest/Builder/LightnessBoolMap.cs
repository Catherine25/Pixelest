// using Pixelest.Extension;
// using Pixelest.Model;
// using static Pixelest.Extension.ColorConstants;
//
// namespace Pixelest.Builder
// {
//     public class LightnessBoolMap : BoolMap
//     {
//         public int Lightness { get; private set; }
//
//         public LightnessBoolMap(MyBitmap bitmap, int lightness): base(bitmap.Size)
//         {
//             Lightness = lightness;
//             
//             for (int i = 0; i < Size.Width; i++)
//                 for (int j = 0; j < Size.Height; j++)
//                 {
//                     // darker color are accepted
//                     bool value = lightness >= bitmap.GetPixel(i,j).Get(Parameter.Lightness);
//                     
//                     if(value)
//                         IsEmpty = false;
//                     
//                     Values[i][j] = value;
//                 }
//         }
//     }
// }