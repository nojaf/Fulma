namespace Elmish.Bulma.Elements

open Elmish
open Elmish.Bulma.BulmaClasses
open Elmish.Bulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

module Table =
    module Types =
        type TableOption =
            | IsBordered
            | IsStripped
            | IsNarrow

        type TableOptions =
            { IsBordered : bool
              IsStripped : bool
              IsNarrow : bool }
            static member Empty =
                { IsBordered = false
                  IsStripped = false
                  IsNarrow = false }

    open Types

    // Styling
    let isBordered = IsBordered
    let isStripped = IsStripped
    // Spacing
    let isNarrow = IsNarrow

    let table options children =
        let parseOptions (result : TableOptions) =
            function
            | IsBordered -> { result with IsBordered = true }
            | IsStripped -> { result with IsStripped = true }
            | IsNarrow -> { result with IsNarrow = true }

        let opts = options |> List.fold parseOptions TableOptions.Empty
        table
            [ classBaseList bulma.table.container [ bulma.table.style.isBordered, opts.IsBordered
                                                    bulma.table.style.isStripped, opts.IsStripped
                                                    bulma.table.spacing.isNarrow, opts.IsNarrow ] ]
            children

    module Row =
        // Row
        let isSelected = ClassName bulma.table.row.state.isSelected
