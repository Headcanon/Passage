using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Isso é uma tentativa de aplicar a estrutura de dados da aula do Wladmir ao meu jogo da ExtraJam */
public class ListaTiles : MonoBehaviour
{
    #region Construção
    List<GameObject> listaTiles;
    int lastPrefabIndex = 0;

    public ListaTiles()
    {
        listaTiles = new List<GameObject>();
    }
    
    public ListaTiles(string pasta)
    {
    	listaTiles = new List<GameObject>();
    	
    	AddFromFolder(pasta);
    }
    #endregion

    #region Adicionar
    public bool Add(GameObject go)
    {
        // Se o GameObject indicado for null...
        if (go == null)
            // Já desiste e retorna falso
            return false;

        // Procura um GameObject com o mesmo nome
        // E se encontrar alguma coisa, ou seja, retornar algo diferente de null...
        if (Procurar(go.name) != null)
            // Retorna false;
            return false;

        // Se passou pelos testes anteriores adiciona o GameObject indicado à lista
        listaTiles.Add(go);
        // E retorna true
        return true;
    }

    public void AddFromFolder(string pasta)
    {
        // Carrega todos os GameObjects dentro da pasta designada e coloca num array
        GameObject[] gos = Resources.LoadAll<GameObject>(pasta);

        // Pra cada GameObject desse array...
        for (int i = 0; i < gos.Length; i++)
        {
            // Asiciona à lista;
            Add(gos[i]);
        }
    }
    #endregion

    #region Remover
    public bool Remove(GameObject go)
    {
        // Se o GameObject indicado foor nulo retorna false
        if (go == null)
            return false;

        // Se não encontrar nenhum GameObject com esse nome retorna false
        if (Procurar(go.name) == null)
            return false;

        // Se passou pelos dois testes anteriores remove o GameObject indicad
        listaTiles.Remove(go);
        // E retorna true
        return true;
    }

    public bool Remove(int i)
    {
        // Se não encontrar nenhum GameObject com esse indice retorna false
        if (Procurar(i) == null)
            return false;

        // Se passou pelo teste anterior
        listaTiles.RemoveAt(i);
        // E retorna true
        return true;
    }

    public bool Remove(string nome)
    {
        // Procura um GameObject com o nome indicado e atribui ao go
        // Se não encontrar nada é nulo
        GameObject go = Procurar(nome);

        // Se go for nulo retorna false
        if (go == null)
            return false;

        // Se go não for nulo remove go
        listaTiles.Remove(go);
        // E retorna true
        return true;
    }
    #endregion

    #region Procurar
    public GameObject Procurar(string nome)
    {
        // Pra cada GameObject na lista...
        for(int i = 0; i < listaTiles.Count; i++)
        {
            // Se o nome do GameObjet for igual ao nome indicado...
            if (listaTiles[i].name == nome)
                // Retorna esse GameObject
                return listaTiles[i];
        }

        // Caso não encontre nada retorna null
        return null;
    }

    public GameObject Procurar(int i)
    {
        // Retorna o GameObject da lista com o indice correspondente
        return listaTiles[i];
    }
    #endregion

    public GameObject AleatorioSemRepetir()
    {
        // Cria um index igual ao último
        int newIndex = lastPrefabIndex;

        // Enquanto esse index for igual ao último...
        while (newIndex == lastPrefabIndex)
        {
            // Cria um novo index aleatório
            newIndex = Random.Range(0, listaTiles.Count);
        }
        // Atualiza o index antigo
        lastPrefabIndex = newIndex;

        // Retorna o GameObject com o index gerado
        return listaTiles[newIndex];
    }

    public int Count()
    {
        return listaTiles.Count;
    }
}
