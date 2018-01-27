using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace VMUP.InteractionVR
{
    public class ControladorVR : MonoBehaviour
    {
        // comprimento do raio que colide com objetos
        public float rayLength = 100f;
        
        // variavel guarda o objeto que e atingido pelo raycast
        private RaycastHit hit;

        // referencia para a camera principal na cena
        public Camera mainCamera;

        // imagem que representa o ponto que interage com os objetos
        public Image rectile;

        // imagem que representa um objeto alvo de interacao
        public Image target;

        // tamanho do ponto quando encontra um objeto interativo
        public Vector2 rectileInteractionSize;

        // tamanho do ponto normal, sem interacao
        public Vector2 rectileNormalSize;

        // texto na cena para debug
        public Text debugText;

        //inicializa o objeto MonoBehaviour
        void Start()
        {

        }

        // executa em todos os frames 
        void Update()
        {
            Interact();
        }

        //----------------------------------------------------------------
        // Interacao do Usuario com objetivos interativos na cena
        //----------------------------------------------------------------

        void Interact()
        {
            //cria um raio que tem origem na posicao da camera e se estende no eixo z da camera (frente)
            Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);

            // se atinge um objeto interativo na cena...
            if (Physics.Raycast(ray, out hit, rayLength))
            {
                //se este objeto e um objeto interativo...
                if (hit.collider.tag.Equals("Object"))
                {
                    // anima a escala do ponto
                    rectile.rectTransform.DOSizeDelta(rectileInteractionSize,1f);

                    // torna-se o objeto alvo vermelho
                    rectile.DOColor(Color.cyan, 1f);

                    //desenha na cena um raio para debug
                    Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.forward, Color.yellow, rayLength);
                }
            }

            // quando nao esta colidindo com objetivos interativos...
            else
            {
               // anima a escala do ponto para a forma inicial
                rectile.rectTransform.DOSizeDelta(rectileNormalSize,1f);

                // retorna a cor padrao do objeto alvo
                rectile.DOColor(Color.white, 1f);
            }
        }
    }
}


