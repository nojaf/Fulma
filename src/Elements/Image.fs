namespace Elmish.Bulma.Elements

open Elmish
open Elmish.Bulma.BulmaClasses
open Elmish.Bulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

module Image =
    module Types =
        type IImageSize =
            | Is16x16
            | Is24x24
            | Is32x32
            | Is48x48
            | Is64x64
            | Is96x96
            | Is128x128

        type IImageRatio =
            | IsSquare
            | Is1by1
            | Is4by3
            | Is3by2
            | Is16by9
            | Is2by1

        let ofImageSize =
            function
            | Is16x16 -> bulma.image.size.is16x16
            | Is24x24 -> bulma.image.size.is24x24
            | Is32x32 -> bulma.image.size.is32x32
            | Is48x48 -> bulma.image.size.is48x48
            | Is64x64 -> bulma.image.size.is64x64
            | Is96x96 -> bulma.image.size.is96x96
            | Is128x128 -> bulma.image.size.is128x128

        let ofImageRatio =
            function
            | IsSquare -> bulma.image.ratio.isSquare
            | Is1by1 -> bulma.image.ratio.is1by1
            | Is4by3 -> bulma.image.ratio.is4by3
            | Is3by2 -> bulma.image.ratio.is3by2
            | Is16by9 -> bulma.image.ratio.is16by9
            | Is2by1 -> bulma.image.ratio.is2by1

        type Option =
            | Size of IImageSize
            | Ratio of IImageRatio

        type Options =
            { Size : string option
              Ratio : string option }
            static member Empty =
                { Size = None
                  Ratio = None }

    open Types

    // Sizes
    let is16x16 = Size Is16x16
    let is24x24 = Size Is24x24
    let is32x32 = Size Is32x32
    let is48x48 = Size Is48x48
    let is64x64 = Size Is64x64
    let is96x96 = Size Is96x96
    let is128x128 = Size Is128x128
    // Ratios
    let isSquare = Ratio IsSquare
    let is1by1 = Ratio Is1by1
    let is4by3 = Ratio Is4by3
    let is3by2 = Ratio Is3by2
    let is16by9 = Ratio Is16by9
    let is2by1 = Ratio Is2by1

    let image options children =
        let parseOptions (result : Options) =
            function
            | Size size -> { result with Size = ofImageSize size |> Some }
            | Ratio ratio -> { result with Ratio = ofImageRatio ratio |> Some }

        let opts = options |> List.fold parseOptions Options.Empty
        figure
            [ ClassName(Helpers.generateClassName bulma.image.container [ opts.Size; opts.Ratio ]) ]
            children
